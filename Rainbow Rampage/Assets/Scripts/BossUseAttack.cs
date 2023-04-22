using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUseAttack : StateMachineBehaviour
{

    public GameObject portal;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject _portal  = Instantiate(portal,animator.transform.position + new Vector3 (0f,2*animator.transform.localScale.y,0f),Quaternion.identity);
        _portal.transform.localScale = animator.transform.localScale;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.FindGameObjectWithTag("Portal") == null)
        {
            animator.SetTrigger("AlreadyAttacked");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AlreadyAttacked");
    }
}
