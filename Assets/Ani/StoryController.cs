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
        sailor.GetComponent<Animator>().SetTrigger("Sick-Standing");
        yield return new WaitForSeconds(3f);

        // ת���������ɫ
        yield return fadeController.FadeIn(0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return fadeController.FadeOut(0.5f);

        // ����3����ʦ����Ա������
        oranges.SetActive(true);
        chef.GetComponent<Animator>().SetTrigger("GiveOrange");
        Debug.Log("GiveOrange");
        yield return new WaitForSeconds(3f);

        // ת���������ɫ
        yield return fadeController.FadeIn(0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return fadeController.FadeOut(0.5f);

        // ����4����Ա������
        sailor.GetComponent<Animator>().SetTrigger("Standing");
        yield return new WaitForSeconds(2f);
    }
}
