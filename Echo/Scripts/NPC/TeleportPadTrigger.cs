using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject teleportUI; // �� UI ������
    public string targetScene = "SceneName"; // ����Ŀ�곡����
    public float stayDuration = 1f;

    private float timer = 0f;
    private bool isPlayerInside = false;
    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            timer = 0f;
            Debug.Log("Player entered the teleport pad trigger area.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            timer = 0f;
            Debug.Log("Player exited the teleport pad trigger area.");
        }
    }

    void Update()
    {
        if (isPlayerInside && !hasTriggered)
        {
            timer += Time.deltaTime;
            if (timer >= stayDuration)
            {
                // �����ռ��ж�
                if (GameManager.instance != null && GameManager.instance.HasCollectedAllWords())
                {
                    hasTriggered = true;
                    teleportUI.SetActive(true); // ��ʾ UI
                    Debug.Log("Player has stayed long enough and collected all words. Showing teleport UI.");
                }
                else
                {
                    Debug.Log("��û�ռ����������֣����ܴ��ͣ�");
                    // ��ѡ��UI��ʾ��������ʾ���㻹������֣���
                    timer = 0f; // ���ü�ʱ������һֱ����
                }
            }
        }
    }


    // UI Button ����
    public void OnConfirm()
    {
        GameManager.instance.ClearCollectedWords();
        SceneManager.LoadScene(targetScene);
    }

    public void OnCancel()
    {
        teleportUI.SetActive(false);
        hasTriggered = false;
        timer = 0f;
    }

    private void Start()
    {
        teleportUI.SetActive(false);
    }
}
