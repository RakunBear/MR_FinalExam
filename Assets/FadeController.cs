using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    private bool isFading = false;

    private void Start()
    {
        if (fadeImage != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeIn(float duration)
    {
        isFading = true;
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            fadeImage.color = color;
            yield return null;
        }

        isFading = false;
    }

    public IEnumerator FadeOut(float duration = 1f)
    {
        isFading = true;
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            fadeImage.color = color;
            yield return null;
        }

        isFading = false;
    }
}
