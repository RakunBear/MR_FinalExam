using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    private bool isFading = false;

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


    public string NextSceneName;
    public float FadeInTime = 1.0f;
    public void ChangeScene(string sceneName = "")
    {
        if (sceneName == "")
        {
            sceneName = NextSceneName;
        }
        StartCoroutine(ChangeInternal(sceneName));
    }

    IEnumerator ChangeInternal(string sceneName)
    {
        yield return FadeIn(FadeInTime);
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);

    }
}
