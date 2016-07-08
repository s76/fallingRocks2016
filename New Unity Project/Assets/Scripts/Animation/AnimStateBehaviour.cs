using UnityEngine;
using System.Collections;
using Core.Model;
using System;

public class AnimStateBehaviour : StateMachineBehaviour
{
    public bool isLoop;
    protected float _CurrentAnimationDuration = -1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!isLoop)
            animator.speed = _CurrentAnimationDuration > 0 ? stateInfo.length / (_CurrentAnimationDuration * stateInfo.speedMultiplier) : 1f;
    }
}
