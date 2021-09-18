using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PatrolBehavior : StateMachineBehaviour
    {
        public Vector3[] points;
        int current;
        private float Speed = 5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            current = 0;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.transform.position != points[current])
            {
                animator.transform.LookAt(points[current]);
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, points[current], Speed * Time.deltaTime);    
            }
            else
            {
                current++;
                if (current > 3)
                {
                    current = 0;
                }
            }

            if ((animator.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).sqrMagnitude < 100)
            {
                animator.SetBool("isFollowing", true);
                animator.SetBool("isPatrolling", false);
            }
        }
    }
}

