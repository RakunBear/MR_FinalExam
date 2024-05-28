using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerInteraction : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerExitEvent;

    private bool CheckPlayer<T>(T target) where T :Component
    {
        return target.CompareTag("Player");
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (CheckPlayer(other))
        {
            OnTriggerEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckPlayer(other))
        {
            OnTriggerExitEvent.Invoke();
        }
    }
}
