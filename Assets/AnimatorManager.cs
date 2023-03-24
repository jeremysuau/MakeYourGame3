using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator playerAnimator;
    public AnimatorController animRun;
    public AnimatorController animJump;
    public AnimatorController animIdle;
    public AnimatorController animFall;

    public void SetAnimatorToRun()
	{
        if(playerAnimator.runtimeAnimatorController != animRun)
        {
			playerAnimator.runtimeAnimatorController = animRun;
		}
	}
    public void SetAnimatorToJump()
    {
		if (playerAnimator.runtimeAnimatorController != animJump)
		{
			playerAnimator.runtimeAnimatorController = animJump;
		}
	}
    public void SetAnimatorToFall()
    {
		if (playerAnimator.runtimeAnimatorController != animFall)
		{
			playerAnimator.runtimeAnimatorController = animFall;
		}
	}
	public void SetAnimatorToIdle()
    {
		if (playerAnimator.runtimeAnimatorController != animIdle)
		{
			playerAnimator.runtimeAnimatorController = animIdle;
		}
	}
}
