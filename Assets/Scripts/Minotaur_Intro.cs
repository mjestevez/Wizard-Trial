using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Intro : StateMachineBehaviour
{
    private int rnd;
    public float attack_speed;
    private float cooldown;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Intro", false);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("FaseFinal"))
        {
            cooldown += Time.deltaTime;
            if (cooldown >= attack_speed)
            {
                rnd = Random.Range(0, 101);
                Debug.Log(rnd);
                if (rnd <= 50)
                {
                    animator.SetInteger("Attack", 2);
                }
                else
                {
                    cooldown = 0;
                }
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
