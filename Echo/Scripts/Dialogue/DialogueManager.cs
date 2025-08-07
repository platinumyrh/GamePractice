using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialogueBox;
    public Text dialogueText;
    public float typingSpeed = 0.05f;

    private string[] lines;
    private int currentLineIndex;



    private void Start()
    {
        dialogueBox.SetActive(false); // 初始时隐藏对话框

    }
    private void Awake()
    {
        Instance = this;
    }

    public void StartDialogue(DialogueData dialogue)
    {
        lines = dialogue.dialogueLines;
        currentLineIndex = 0;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";
        foreach (char letter in lines[currentLineIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (dialogueBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueText.text == lines[currentLineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[currentLineIndex]; // 立即显示当前整行
            }
        }
    }

    void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}
