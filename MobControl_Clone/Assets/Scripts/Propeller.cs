using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    Animator animator;
    [SerializeField] BoxCollider windCollider;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimatioanControl(int state)
    {
        if (state == 1)
        {
            animator.SetBool("Start", true);
            windCollider.enabled = true;
        }
        else
        {
            animator.SetBool("Start", false);
            StartCoroutine(AnimTimer());
            windCollider.enabled = false;
        }
            
        
    }
    IEnumerator AnimTimer()
    {
        yield return new WaitForSeconds(3f);
        AnimatioanControl(1);
    }
}
