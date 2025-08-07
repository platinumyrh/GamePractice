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

            // �������������ʾ˵��
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
        gameObject.SetActive(true);  // �򿪱���UI
        RefreshUI();                 // ˢ�±�����ʾ����
    }

    public void HideInventory()
    {
        tooltipPanel.SetActive(false); // �ر���ʾ��������ţ�
        gameObject.SetActive(false);   // �رձ���UI
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
