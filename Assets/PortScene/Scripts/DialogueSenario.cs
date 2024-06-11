using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSenario : MonoBehaviour
{
    public Page[] Pages;

    [SerializeField]
    TMP_Text nameText;
    [SerializeField]
    TMP_Text descriptionText;

    [SerializeField]
    private int pageNum = 0;

    private void Start() 
    {
        NextPage();
    }

    public void NextPage()
    {
        nameText.text = Pages[pageNum].Name;
        descriptionText.text = Pages[pageNum].Description;
        ++pageNum;
    }
    

    [System.Serializable]
    public class Page
    {
        public string Name;
        [TextArea]
        public string Description;
    }
}
