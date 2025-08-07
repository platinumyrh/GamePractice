using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;          // 跟随目标（角色）
    public float smoothSpeed = 0.125f; // 平滑跟随速度
    public Vector3 offset;            // 摄像机偏移量

    public Vector2 minBounds;         // 地图左下边界（世界坐标）
    public Vector2 maxBounds;         // 地图右上边界（世界坐标）

    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // 限制摄像机X、Y轴范围，避免超出地图边界
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

        // 平滑移动摄像机到限制后的位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
