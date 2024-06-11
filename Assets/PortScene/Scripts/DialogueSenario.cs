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

    private void Start() 
    {
        NextPage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextPage();
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
        ++pageNum;
    }

    public void EndPage()
    {
        EndEvent?.Invoke();
        gameObject.SetActive(false);
    }
    

    [System.Serializable]
    public class Page
    {
        public string Name;
        [TextArea]
        public string Description;
    }
}
