using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class YSortingOrder : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // 乘以 -100 变成整数，保证整数排序且Y越小排序越大
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
}
