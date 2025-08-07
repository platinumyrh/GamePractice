using UnityEngine;
using System.Collections;

public class TeleportTextTrigger : MonoBehaviour
{
    public SpriteRenderer textTop;
    public SpriteRenderer textBottom;
    public SpriteRenderer textLeft;
    public SpriteRenderer textRight;

    public float fadeDuration = 0.5f;

    private Coroutine fadeCoroutine;


    void Start()
    {
        SpriteRenderer[] texts = { textTop, textBottom, textLeft, textRight };
        for (int i = 0; i < texts.Length; i++)
        {
            Color c = texts[i].color;
            c.a = 0f; // 初始化为透明
            texts[i].color = c; // 重新赋值，
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeTexts(1f)); // 渐显
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gameObject.activeInHierarchy) return; // ✅ 避免在物体失活时调用协程

            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeTexts(0f)); // 渐隐
        }
    }

    IEnumerator FadeTexts(float targetAlpha)
    {
        SpriteRenderer[] texts = { textTop, textBottom, textLeft, textRight };
        float time = 0f;

        // 记录初始透明度
        float[] startAlphas = new float[texts.Length];
        for (int i = 0; i < texts.Length; i++)
        {
            startAlphas[i] = texts[i].color.a;
        }

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;
            for (int i = 0; i < texts.Length; i++)
            {
                Color c = texts[i].color;
                c.a = Mathf.Lerp(startAlphas[i], targetAlpha, t);
                texts[i].color = c;
            }
            yield return null;
        }

        // 强制设为最终值
        for (int i = 0; i < texts.Length; i++)
        {
            Color c = texts[i].color;
            c.a = targetAlpha;
            texts[i].color = c;
        }
    }
}
