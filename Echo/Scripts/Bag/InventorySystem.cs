using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public List<InventoryItem> items = new List<InventoryItem>();
    public int maxSlots = 12;

    private void Awake()
    {
        // 保证单例唯一性
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // 切场景不销毁
    }

    public bool AddItem(InventoryItem newItem)
    {
        if (items.Count >= maxSlots) return false;

        items.Add(newItem);
        return true;
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

}
