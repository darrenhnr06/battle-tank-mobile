using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class IdleBehavior : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isPatrolling", true);
        }
    }
}

