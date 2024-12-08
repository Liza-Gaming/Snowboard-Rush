using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

/**
 * For the snow board controlling I watched this video: https://www.youtube.com/watch?v=XF4HzViMSRk&t=25s&ab_channel=BlumStudios
 * For the "in air" physics and roattions in the air I got help from chat GPT.
 */
public class HoverboardController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Control the player using defined keyboard buttons.")]
    public InputAction PlayerControls;
    // The Rigidbody component attached to the hoverboard, used for physics interactions.
    private Rigidbody hb;

    [SerializeField]
    [Tooltip("Force applied to move the hoverboard forward.")]
    public float moveForce;

    [SerializeField]
    [Tooltip("Torque applied to the hoverboard for turning.")]
    public float turnTorque;

    [SerializeField]
    [Tooltip("Distance to check for the ground below the hoverboard.")]
    public float groundCheckDistance = 0.5f;

    [SerializeField]
    [Tooltip("Layer that represents the ground.")]
    public LayerMask groundLayer;

    [SerializeField]
    [Tooltip("UI Text for displaying points when rotating in the air")]
    public Text Fliptext;

    // Array of transforms used to check for grounding
    public Transform[] anchors = new Transform[4];

    // Tracks whether the hoverboard was on the ground in the last frame.
    private bool wasOnGround = true;

    //Accumulates the rotation the player makes while in the air.
    private float rotationStore = 0f;

    // Threshold for recognizing a 180-degree rotation while airborne (50% of 360).
    private const float fullRotation = 360f * 0.5f;

    void OnEnable()
    {
        PlayerControls.Enable();
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }

    void Start()
    {
        hb = GetComponent<Rigidbody>();
    }

    // Applies moving and rotation based on user input to simulate turning.
    void FixedUpdate()
    {
        Vector2 inputVector = PlayerControls.ReadValue<Vector2>();
        hb.AddTorque(inputVector.x * turnTorque * transform.up);

        if (IsOnGround())
        {
            // Allow forward movement only when grounded
            hb.AddForce(inputVector.y * moveForce * transform.forward);

            // Reset rotation tracking when touching ground
            if (!wasOnGround)
            {
                CheckAndResetRotation();
                wasOnGround = true;
            }
        }
        else
        {
            // Track rotation while in the air
            rotationStore += Mathf.Abs(hb.angularVelocity.y * Time.fixedDeltaTime * Mathf.Rad2Deg);
            wasOnGround = false;
        }
    }

    // Checks if the hoverboard is touching the ground.
    private bool IsOnGround()
    {
        foreach (Transform anchor in anchors)
        {
            if (Physics.Raycast(anchor.position, Vector3.down, groundCheckDistance, groundLayer))
            {
                return true;
            }
        }
        return false;
    }
    private void CheckAndResetRotation()
    {
        if (rotationStore >= fullRotation)
        {
            // Award a point
            Fliptext.text = "+1 point";
            ScoreManager.instance.AddPoint();
            StartCoroutine(ShowFlipText());
        }
        rotationStore = 0; // Reset rotation tracking
    }
    private IEnumerator ShowFlipText()
    {
        // Display the text for 1 second
        yield return new WaitForSeconds(1);
        Fliptext.text = ""; // Clear the text 
    }

}