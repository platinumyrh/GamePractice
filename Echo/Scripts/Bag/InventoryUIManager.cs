using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform slotParent;
    public GameObject tooltipPanel;
    public Text tooltipText;

    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in InventorySystem.Instance.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponent<Image>().sprite = item.icon;

            // 设置鼠标悬浮显示说明
            EventTrigger trigger = slot.AddComponent<EventTrigger>();

            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((e) => ShowTooltip(item.description));
            trigger.triggers.Add(entryEnter);

            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((e) => HideTooltip());
            trigger.triggers.Add(entryExit);
        }

    }
    public void ShowTooltip(string description)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = description;
    }
    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
    public void ShowInventory()
    {
        gameObject.SetActive(true);  // 打开背包UI
        RefreshUI();                 // 刷新背包显示内容
    }

    public void HideInventory()
    {
        tooltipPanel.SetActive(false); // 关闭提示框（如果开着）
        gameObject.SetActive(false);   // 关闭背包UI
    }

    public void ToggleInventory()
    {
        if (gameObject.activeSelf)
        {
            HideInventory();
        }
        else
        {
            ShowInventory();
        }
    }


}
