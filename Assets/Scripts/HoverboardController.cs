using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

////https://www.youtube.com/watch?v=XF4HzViMSRk&ab_channel=BlumStudios
///I used chat GPT to for controlling board in air
public class HoverboardController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Control the player with defined keyboard buttons")]
    public InputAction PlayerControls;

    Rigidbody hb;
    public float moveForce;
    public float turnTorque;
    public float groundCheckDistance = 0.5f; // Distance to check for the ground below
    public LayerMask groundLayer; // Layer that represents the ground

    Vector3 moveDir = Vector3.zero;

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

    public Transform[] anchors = new Transform[4]; // Anchors used for ground checking

    void FixedUpdate()
    {
        Vector2 inputVector = PlayerControls.ReadValue<Vector2>();
        hb.AddTorque(inputVector.y * turnTorque * transform.up);
        if (IsOnGround())
        {
            hb.AddForce(inputVector.x * moveForce * transform.forward);
        }
    }

    bool IsOnGround()
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
}