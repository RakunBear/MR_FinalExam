using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class close : MonoBehaviour
{
    [SerializeField]
    SceneTransition SceneTransition;
    [SerializeField]
    TMP_Text guideText;
    public float TypeTime = 1.0f;

    Coroutine coroutine;

    // Start is called before the first frame update
    private bool state;
    void Start()
    {
        state=true;
        coroutine = StartCoroutine(TypeAnimation(guideText));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(state==true)
            {
                // gameObject.SetActive(false);
                StopType();
                SceneTransition.ChangeScene();
                state=false;
        
            }
        }
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
        }

        public void StopType()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            guideText.maxVisibleCharacters = guideText.text.Length;
        }
}
