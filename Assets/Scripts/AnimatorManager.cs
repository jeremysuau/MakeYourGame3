using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator playerAnimator;
    public RuntimeAnimatorController animRun;
    public RuntimeAnimatorController animJump;
    public RuntimeAnimatorController animIdle;
    public RuntimeAnimatorController animFall;

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
