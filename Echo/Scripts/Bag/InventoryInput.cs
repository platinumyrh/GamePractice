using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public InventoryUIManager inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  // 你想用哪个键，改这里
        {
            inventoryUI.ToggleInventory();
        }
    }
}
