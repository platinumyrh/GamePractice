using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;          // ����Ŀ�꣨��ɫ��
    public float smoothSpeed = 0.125f; // ƽ�������ٶ�
    public Vector3 offset;            // �����ƫ����

    public Vector2 minBounds;         // ��ͼ���±߽磨�������꣩
    public Vector2 maxBounds;         // ��ͼ���ϱ߽磨�������꣩

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

        // ���������X��Y�᷶Χ�����ⳬ����ͼ�߽�
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

        // ƽ���ƶ�����������ƺ��λ��
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
