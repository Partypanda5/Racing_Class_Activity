using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object for the camera to follow.
    public float distanceBehind = 5f; // How far behind the target the camera should stay.
    public float cameraHeight = 2f; // How much above (or below) the target the camera should stay.
    public float smoothSpeed = 0.125f; // This will make the camera movement smoother.

    private void Update()
    {
        // Calculate the desired position behind the target and with the specified height
        Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * cameraHeight;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}