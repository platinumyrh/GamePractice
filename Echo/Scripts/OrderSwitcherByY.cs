using UnityEngine;

public class OrderSwitcherByY : MonoBehaviour
{
    public Transform player; // 拖拽玩家对象进来
    public int orderAbove = 2;  // 玩家在上面时的层级
    public int orderBelow = 0;  // 玩家在下面时的层级
    public float switchY;       // y坐标界限（一般就是物体中心）

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (switchY == 0f)
        {
            switchY = transform.position.y; // 默认使用当前物体 y 坐标为界限
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
