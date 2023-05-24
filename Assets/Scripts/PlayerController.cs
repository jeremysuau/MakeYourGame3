using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public Collider col;
	public PhysicMaterial groundMat;
	public PhysicMaterial midAirMat;
	private Footstep footstep;
	public Animator playerAnimator;
	private PlayerInputActions playerInputActions;

	public float inputX;
	public float inputY;
	private Vector3 direction;
	private Vector3 moveDir;
	public float speedMouvement;
	public float jumpForce;
	public bool grounded;
	public bool isTakingDamage;

	private Transform cam;
	private float turnSmoothVelocity;
	private float turnSmoothtime = 0.1f;
	public LayerMask groundedLayerMask;

	private void Awake()
	{
		cam = Camera.main.transform;
		rb = GetComponent<Rigidbody>();
		footstep = GetComponent<Footstep>();

		//permet d'activer des input
		playerInputActions = new PlayerInputActions();
		playerInputActions.Player.Enable();
		playerInputActions.Player.Jump.performed += Jump;
		playerInputActions.Player.Move.performed += Move;
		playerInputActions.Player.Move.canceled += StopMove;
	}

	private void Jump(InputAction.CallbackContext obj)
	{
		//verifie l'input et le fait qu'on soit au sol
		if (true && grounded)
		{
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
	}

	private void FixedUpdate()
	{
		IsGrounded();
	}

	private void Update()
	{
		inputX = playerInputActions.Player.Move.ReadValue<Vector2>().x;
		inputY = playerInputActions.Player.Move.ReadValue<Vector2>().y;

		if(inputX != 0 || inputY != 0)
		{
			//defini la direction de deplacement grace aux inputs
			direction = new Vector3(inputX, 0f, inputY).normalized;

			//oriente correctement le joueur suivant son deplacement
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
			moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			//applique le mouvement
			rb.velocity = new Vector3(moveDir.x * speedMouvement, rb.velocity.y, moveDir.z * speedMouvement);
		}
		else
		{
			if (grounded)
			{
				rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
			}
		}

		//ANIMATION
		playerAnimator.SetFloat("Speed", Mathf.Abs(inputX) + Mathf.Abs(inputY));
		playerAnimator.SetBool("Grounded", grounded);

	}

	//gestion des mouvement lateraux du joueur
	public void Move(InputAction.CallbackContext obj)
	{
		
	}

	public void StopMove(InputAction.CallbackContext obj)
	{
		if (grounded)
		{
			rb.velocity = Vector3.zero;
		}
	}

	//check si le joueur est au sol ou non
	public void IsGrounded()
	{
		grounded = Physics.CheckSphere(transform.position, 0.1f, groundedLayerMask);
		if (grounded)
		{
			col.material = groundMat;
		}
		else 
		{
			col.material = midAirMat;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.1f);  
	}

	public IEnumerator TakingDamage() 
	{ 
		yield return new WaitForSeconds(0.25f);
		isTakingDamage = false;
	}
}