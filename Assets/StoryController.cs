using UnityEngine;
using System.Collections;

public class StoryController : MonoBehaviour
{
    public FadeController fadeController;
    public GameObject chef;
    public GameObject sailor;
    public GameObject oranges;

    private void Start()
    {
        StartCoroutine(StorySequence());
    }

    private IEnumerator StorySequence()
    {
        // 淡出黑色
        yield return fadeController.FadeOut();

        // 场景1：船员得了坏血病
        sailor.GetComponent<Animator>().SetTrigger("sick");
        yield return new WaitForSeconds(2f);

        // 转场：淡入黑色
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // 转场：淡入黑色
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // 场景3：厨师给船员吃橘子
        oranges.SetActive(true);
        chef.GetComponent<Animator>().SetTrigger("GiveOranges");
        yield return new WaitForSeconds(2f);

        // 转场：淡入黑色
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // 场景4：船员病好了
        sailor.GetComponent<Animator>().SetTrigger("Standing");
        yield return new WaitForSeconds(2f);
    }
}
