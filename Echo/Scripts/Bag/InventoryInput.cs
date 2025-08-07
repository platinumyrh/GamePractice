using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    public InventoryUIManager inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  // �������ĸ�����������
        {
            inventoryUI.ToggleInventory();
        }
    }
}
