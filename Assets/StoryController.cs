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
        // ������ɫ
        yield return fadeController.FadeOut();

        // ����1����Ա���˻�Ѫ��
        sailor.GetComponent<Animator>().SetTrigger("sick");
        yield return new WaitForSeconds(2f);

        // ת���������ɫ
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // ת���������ɫ
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // ����3����ʦ����Ա������
        oranges.SetActive(true);
        chef.GetComponent<Animator>().SetTrigger("GiveOranges");
        yield return new WaitForSeconds(2f);

        // ת���������ɫ
        yield return fadeController.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        yield return fadeController.FadeOut(1f);

        // ����4����Ա������
        sailor.GetComponent<Animator>().SetTrigger("Standing");
        yield return new WaitForSeconds(2f);
    }
}
