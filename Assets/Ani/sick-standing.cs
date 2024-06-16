using UnityEngine;

public class sickstanding : MonoBehaviour
{
    private Animator animator;
    public bool Sickstanding;


    void Start()
    {
        animator = GetComponent<Animator>();     
    }

    void Update()
    {
        if (Sickstanding)
        {
            animator.SetBool("sickstanding", true);
        }
        else
        {
            animator.SetBool("sickstanding", false);
        }
    }
}