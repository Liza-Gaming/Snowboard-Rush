using UnityEngine;
/**
 * This code is from https://www.youtube.com/watch?v=ZPUtQ4pGGWs&ab_channel=chonk
 * This script makes the camera follow a target.
 * Smoothly transitions the camera to prevent jarring movement.
 */
public class CameraFollower : MonoBehaviour
{
    // The offset distance between the camera and the target.
    private Vector3 _offset;

    [SerializeField]
    [Tooltip("Target transform for the camera to follow")]
    private Transform target;

    [SerializeField]
    [Tooltip("Time taken to smooth the camera movement.")]
    private float smoothTime;

    // Used for storing the current velocity of the camera for smoothing.
    private Vector3 _currentVelocity = Vector3.zero;

    // Sets the initial offset between the camera and the target.
    // Called when the script instance is being loaded.
    private void Awake() => _offset = transform.position - target.position;

    // Updates the camera's position.
    // Smoothly moves the camera towards the target position based on its current velocity.
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}

