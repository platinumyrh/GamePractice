using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private HashSet<string> collectedWords = new HashSet<string>();

    public GameObject dialogBox;      // �����������
    public Text dialogText; // ��ʾ���ı�����


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded; // ���ĳ��������¼�
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
        return collectedWords.Count >= 4; // �����4�ĳ������������
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
        // �г��������³������ҵ�����������
        dialogBox = GameObject.Find("DialogBox");
        if (dialogBox != null)
            dialogText = dialogBox.GetComponentInChildren<Text>();

        if (dialogBox != null)
            dialogBox.SetActive(false);
    }
}
