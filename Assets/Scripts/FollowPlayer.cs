using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(cameraTarget.position);
    }

    private void OnDrawGizmos()
    {
        if (!cameraTarget) return;

        Vector3 targetPosition = cameraTarget.position + offset;

        // 📍 1. Draw line from camera to target position (offset position)
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, targetPosition);

        // 🎯 2. Draw line from camera to actual player (LookAt target)
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, cameraTarget.position);

        // 📦 3. Draw a sphere where the camera is trying to go (target position)
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(targetPosition, 0.3f);

        // 🧍‍♂️ 4. Draw a sphere at the player position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(cameraTarget.position, 0.2f);

        // 📐 5. Draw the raw offset vector from the player
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cameraTarget.position, targetPosition);
    }
}
