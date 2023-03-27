using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerInputs playerInputs;
    public PlayerController playerController;

	private void Update()
	{
		playerAnimator.SetFloat("Speed", Mathf.Abs(playerInputs.inputX) + Mathf.Abs(playerInputs.inputY));
		playerAnimator.SetBool("Grounded", playerController.grounded);
	}
}
