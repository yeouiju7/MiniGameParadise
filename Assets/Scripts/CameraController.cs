using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    private float initialX;

    void Start()
    {
        initialX = transform.position.x;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(initialX, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}