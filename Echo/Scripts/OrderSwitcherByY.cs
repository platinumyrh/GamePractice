using UnityEngine;

public class OrderSwitcherByY : MonoBehaviour
{
    public Transform player; // ��ק��Ҷ������
    public int orderAbove = 2;  // ���������ʱ�Ĳ㼶
    public int orderBelow = 0;  // ���������ʱ�Ĳ㼶
    public float switchY;       // y������ޣ�һ������������ģ�

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (switchY == 0f)
        {
            switchY = transform.position.y; // Ĭ��ʹ�õ�ǰ���� y ����Ϊ����
        }
    }

    void Update()
    {
        if (player == null || sr == null) return;

        if (player.position.y > switchY)
        {
            sr.sortingOrder = orderAbove;
        }
        else
        {
            sr.sortingOrder = orderBelow;
        }
    }
}
