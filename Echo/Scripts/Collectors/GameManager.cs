using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private HashSet<string> collectedWords = new HashSet<string>();

    public GameObject dialogBox;      // 整个背景面板
    public Text dialogText; // 显示的文本内容


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded; // 订阅场景加载事件
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public bool CollectWord(string wordID)
    {

        if (!collectedWords.Contains(wordID)) 
        {
            collectedWords.Add(wordID);
            return true;
        }
        return false;

    }

    public bool HasCollectedAllWords()
    {
        return collectedWords.Count >= 4; // 这里的4改成你的文字总数
    }

    public void ClearCollectedWords()
    {
        collectedWords.Clear();
    }
    public int CollectedCount()
    {
        return collectedWords.Count;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 切场景后在新场景里找到这两个引用
        dialogBox = GameObject.Find("DialogBox");
        if (dialogBox != null)
            dialogText = dialogBox.GetComponentInChildren<Text>();

        if (dialogBox != null)
            dialogBox.SetActive(false);
    }
}
