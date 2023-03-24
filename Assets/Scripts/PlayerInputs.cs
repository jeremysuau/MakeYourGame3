using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
	private PlayerInput playerInput;
	private PlayerInputActions playerInputActions;

	public float inputX;
	public float inputY;
	public bool inputJump;

	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		playerInputActions = new PlayerInputActions();
		playerInputActions.Enable();
	}

	private void Update()
	{
		inputX = playerInputActions.Player.Move.ReadValue<Vector2>().x;
		inputY = playerInputActions.Player.Move.ReadValue<Vector2>().y;
		inputJump = playerInputActions.Player.Jump.triggered;
	}
}
