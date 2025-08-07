using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public InventoryItem item;  // ��Ҫ�����Ʒ���ݣ�Inspector����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool added = InventorySystem.Instance.AddItem(item);
            if (added)
            {
                // �������UI����ˢ��
                InventoryUIManager uiManager = FindObjectOfType<InventoryUIManager>();
                if (uiManager != null && uiManager.gameObject.activeSelf)
                {
                    uiManager.RefreshUI();
                }

                // ��Ʒ�������ˣ����ٻ�����
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("�������ˣ��޷�ʰȡ");
            }
        }
    }
}
