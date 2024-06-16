using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSenario : MonoBehaviour
{
    public Page[] Pages;

    [SerializeField]
    TMP_Text nameText;
    [SerializeField]
    TMP_Text descriptionText;
    public UnityEvent EndEvent = new UnityEvent();

    [SerializeField]
    private int pageNum = 0;

    [SerializeField]
    TMP_Text guideText;
    public float TypeTime = 1.0f;

    Coroutine coroutine;

    private void Start() 
    {
        NextPage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (coroutine != null)
            {
                StopType();
            }
            else
            {
                NextPage();
            }
        }
    }

    public void NextPage()
    {
        if (pageNum >= Pages.Length)
        {
            EndPage();
            return;
        }

        nameText.text = Pages[pageNum].Name;
        descriptionText.text = Pages[pageNum].Description;
        coroutine = StartCoroutine(TypeAnimation(descriptionText));
        ++pageNum;
    }

    public void EndPage()
    {
        EndEvent?.Invoke();
        gameObject.SetActive(false);
    }

     IEnumerator TypeAnimation(TMP_Text tMP_Text)
        {
            int maxVisible = tMP_Text.text.Length;
            int curVisible = 0;
            float curTime = 0.0f;

            while (curTime < 1.0f)
            {
                curTime += Time.deltaTime / TypeTime;

                curVisible++;
                tMP_Text.maxVisibleCharacters = Mathf.FloorToInt(maxVisible * curTime);

                yield return null;
            }
            
            tMP_Text.maxVisibleCharacters = maxVisible;
            coroutine = null;
        }

        public void StopType()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = null;
            guideText.maxVisibleCharacters = guideText.text.Length;
        }
    

    [System.Serializable]
    public class Page
    {
        public string Name;
        [TextArea]
        public string Description;
    }
}
