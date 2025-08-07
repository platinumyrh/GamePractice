using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject teleportUI; // 拖 UI 面板进来
    public string targetScene = "SceneName"; // 设置目标场景名
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
                // 新增收集判断
                if (GameManager.instance != null && GameManager.instance.HasCollectedAllWords())
                {
                    hasTriggered = true;
                    teleportUI.SetActive(true); // 显示 UI
                    Debug.Log("Player has stayed long enough and collected all words. Showing teleport UI.");
                }
                else
                {
                    Debug.Log("还没收集齐所有文字，不能传送！");
                    // 可选加UI提示：例如显示“你还差几个文字！”
                    timer = 0f; // 重置计时，避免一直卡着
                }
            }
        }
    }


    // UI Button 调用
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
