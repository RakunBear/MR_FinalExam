using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlterCanvas : MonoBehaviour
{
    public bool IsAlive = true;
    public UnityEvent PressEvent = new UnityEvent();

    public void SetActive(bool isActive)
    {
        if (!IsAlive) return;

        gameObject.SetActive(isActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Press();
        }
    }

    public void Press()
    {
        SetActive(false);
        IsAlive = false;
        PressEvent.Invoke();
    }
}
