using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Vector3 offset;
    public Transform target;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
    }
}