using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Attack2 : StateMachineBehaviour
{
    public GameObject bullet;
    private GameObject enemy;
    private float timer;
    private AudioSource sonido;
    public AudioClip clip;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        sonido = enemy.GetComponent<AudioSource>();
        sonido.clip = clip;
        sonido.playOnAwake = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 1)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            shoot();
        }
    }
    private void shoot()
    {
        for(int i=0; i<8; i++)
        {
            Proyectil scriptProyectil = bullet.GetComponent<Proyectil>();
            scriptProyectil.speed = 15;
            Vector2 attack_direction = new Vector2(0, 0);
            switch (i)
            {
                case 0:
                    attack_direction.x = 0;
                    attack_direction.y = 1;
                    break;
                case 1:
                    attack_direction.x = 0.5f;
                    attack_direction.y = 0.5f;
                    break;
                case 2:
                    attack_direction.x = 1;
                    attack_direction.y = 0;
                    break;
                case 3:
                    attack_direction.x = 0.5f;
                    attack_direction.y = -0.5f;
                    break;
                case 4:
                    attack_direction.x = 0;
                    attack_direction.y = -1;
                    break;
                case 5:
                    attack_direction.x = -0.5f;
                    attack_direction.y = -0.5f;
                    break;
                case 6:
                    attack_direction.x = -1;
                    attack_direction.y = 0;
                    break;
                case 7:
                    attack_direction.x = -0.5f;
                    attack_direction.y = 0.5f;
                    break;
            }
            scriptProyectil.direction = attack_direction;
            scriptProyectil.enemigo = true;
            Instantiate(bullet, enemy.transform.position, Quaternion.identity);
            sonido.Play();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Attack", 0);
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
