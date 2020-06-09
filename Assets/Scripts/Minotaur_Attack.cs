using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Attack : StateMachineBehaviour
{
    public GameObject area;
    public GameObject area2;
    public GameObject avisador;
    public GameObject avisador2;
    private GameObject enemy;
    private GameObject areaCreada;
    private GameObject avisadorCreado;
    private bool aviso;
    private float time;
    private AudioSource sonido;
    public AudioClip clip;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aviso = true;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        sonido = enemy.GetComponent<AudioSource>();
        sonido.clip = clip;
        sonido.playOnAwake = false;
        time = 0;
        if(animator.GetBool("FaseFinal")){
            area = area2;
            avisador = avisador2;
        }


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aviso)
        {
            avisadorCreado = Instantiate(avisador, enemy.transform.position, Quaternion.identity);
            aviso = false;
        }
        if (time >= 0.5)
        {
            areaCreada = Instantiate(area, enemy.transform.position, Quaternion.identity);
            sonido.Play();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Attack", 0);
        Destroy(areaCreada);
        Destroy(avisadorCreado);
    }

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
