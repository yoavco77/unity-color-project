using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossUseAttack : StateMachineBehaviour
{
    public GameObject portal;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 portalPos = animator.transform.position + new Vector3(0f,2*animator.transform.localScale.y,0f);
        GameObject _portal =  Instantiate(portal, portalPos, Quaternion.identity);
        _portal.transform.localScale = animator.transform.localScale;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         while (GameObject.FindGameObjectWithTag("Portal") != null)
         {

         }
        animator.SetTrigger("GoIdle");
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
