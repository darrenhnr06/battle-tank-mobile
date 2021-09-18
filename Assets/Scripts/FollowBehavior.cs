using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class FollowBehavior : StateMachineBehaviour
    {
        private Transform playerPos;
        private float Speed = 5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
            animator.gameObject.GetComponent<EnemyView>().Fire();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(playerPos != null)
            {
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, Speed * Time.deltaTime);

                animator.transform.LookAt(playerPos);
                if ((animator.transform.position - playerPos.position).sqrMagnitude > 100)
                {
                    animator.SetBool("isFollowing", false);
                    animator.SetBool("isPatrolling", true);
                }
            }

            else if(playerPos == null)
            {
                playerPos = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }
    }
}


