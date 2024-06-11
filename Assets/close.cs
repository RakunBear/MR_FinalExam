using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    // Start is called before the first frame update
    private bool state;
    void Start()
    {
        state=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(state==true)
            {
                gameObject.SetActive(false);
                state=false;
        
            }
        }
    }
}
