using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Nhân vật mà camera sẽ theo dõi
    public float smoothSpeed = 0.125f; // Tốc độ chuyển động mượt của camera
    public float offsetX; // Khoảng cách giữa camera và nhân vật
    public float offsetY; // Khoảng cách giữa camera và nhân vật


    void LateUpdate()
    {
        var desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}
