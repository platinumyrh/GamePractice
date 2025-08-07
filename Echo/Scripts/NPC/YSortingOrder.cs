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
        // ���� -100 �����������֤����������YԽС����Խ��
        sr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
}
