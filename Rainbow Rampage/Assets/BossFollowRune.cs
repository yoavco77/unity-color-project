using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowRune : StateMachineBehaviour
{
    public GameObject[] Runes;
    public int randomRune;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Runes = GameObject.FindGameObjectsWithTag("Rune");
        randomRune = Random.Range(0, 3);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Vector2 runePos = Runes[randomRune].transform.position;
        animator.GetComponent<Transform>().position = Vector2.MoveTowards(animator.GetComponent<Transform>().position, runePos, 3 * Time.fixedDeltaTime);
        if (animator.GetComponent<Transform>().position == Runes[randomRune].transform.position)
        {
            animator.SetTrigger("Attack");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
