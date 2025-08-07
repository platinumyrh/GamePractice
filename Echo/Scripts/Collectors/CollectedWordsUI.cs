using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectedWordsUI : MonoBehaviour
{
  public TMP_Text collectedWordsText;
  public int totalWords=4;


    private void Update()
    {
        int collectedCount =GameManager.instance != null ? GameManager.instance.CollectedCount() : 0;
        collectedWordsText.text = $"Word Collected   {collectedCount} / {totalWords}";
    }

}
