using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

//https://www.youtube.com/watch?v=XF4HzViMSRk&ab_channel=BlumStudios
public class HoverboardController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Control the player with defined keyboard buttons")]
    public InputAction PlayerControls;

    Rigidbody hb;
    public float mult;
    public float moveForce;
    public float turnTorque;

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

    public Transform[] anchors = new Transform[4];
    public RaycastHit[] hits = new RaycastHit[4];

    void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
            ApplyF(anchors[i], hits[i]);

        Vector2 inputVector = PlayerControls.ReadValue<Vector2>();

        hb.AddForce(inputVector.x * moveForce * transform.forward);
        hb.AddTorque(inputVector.y * turnTorque * transform.up);

    }

    void ApplyF(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            hb.AddForceAtPosition(transform.up * force * mult, anchor.position, ForceMode.Acceleration);
        }
    }

}
