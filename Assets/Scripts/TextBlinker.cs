using UnityEngine;
using TMPro;

public class TextBlinker : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        if (targetText == null) targetText = GetComponent<TextMeshProUGUI>();
        if (targetText != null)
        {
            StartCoroutine(SmoothBlinkEffect()); 
        }
    }

  
    private System.Collections.IEnumerator SmoothBlinkEffect()
    {
        while (true)
        {
            yield return StartCoroutine(FadeToAlpha(0.0f, fadeDuration));
            yield return StartCoroutine(FadeToAlpha(1.0f, fadeDuration));
        }
    }

    
    private System.Collections.IEnumerator FadeToAlpha(float targetAlpha, float duration)
    {
        Color color = targetText.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            
            time += Time.deltaTime;  
            float t = time / duration;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            targetText.color = color;

            yield return null;
        }

 
        color.a = targetAlpha;
        targetText.color = color;
    }
}