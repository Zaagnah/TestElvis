using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float AnimSmoothTime = .1f;
    NavMeshAgent agent;
     Animator animator;
     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
     void Update()
    {
        
        MoveAnim();
        
    }

    private void MoveAnim()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, AnimSmoothTime, Time.deltaTime);
    }
   

}
