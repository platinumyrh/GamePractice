using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public InventoryItem item;  // 你要捡的物品数据，Inspector拖入

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool added = InventorySystem.Instance.AddItem(item);
            if (added)
            {
                // 如果你想UI立刻刷新
                InventoryUIManager uiManager = FindObjectOfType<InventoryUIManager>();
                if (uiManager != null && uiManager.gameObject.activeSelf)
                {
                    uiManager.RefreshUI();
                }

                // 物品被捡走了，销毁或隐藏
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("背包满了，无法拾取");
            }
        }
    }
}
