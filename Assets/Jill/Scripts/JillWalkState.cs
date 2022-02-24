using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JillWalkState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform playerLocation;
    float attackRange = 1.5f;
    private AudioSource audioSource;

    public AudioClip walkSound1;
    public AudioClip walkSound2;
    public AudioClip walkSound3;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        audioSource = animator.GetComponent<AudioSource>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(playerLocation.position);

        float distance = Vector3.Distance(animator.transform.position, playerLocation.position);
        if (distance <= attackRange)
        {
            animator.SetBool("isAttacking", true);
        }

        if (!audioSource.isPlaying)
        {
            int randInt = Random.Range(1, 4);

            if (randInt == 1)
            {
                audioSource.clip = walkSound1;
            } else if (randInt == 2)
            {
                audioSource.clip = walkSound2;
            } else
            {
                audioSource.clip = walkSound3;
            }
            audioSource.Play();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
