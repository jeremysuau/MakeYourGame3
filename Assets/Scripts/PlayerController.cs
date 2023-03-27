using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	private PlayerInputs playerInputs;
	private Rigidbody rb;
	private CapsuleCollider capsuleCollider;

	public float speedMouvement;
	public float jumpForce;
	public bool grounded;

	private Transform cam;
	private float turnSmoothVelocity;
	private float turnSmoothtime = 0.1f;
	private float distToGround;

	private void Awake()
	{
		cam = Camera.main.transform;
		playerInputs = GetComponent<PlayerInputs>();
		rb = GetComponent<Rigidbody>();
		capsuleCollider = GetComponent<CapsuleCollider>();
	}

	private void Start()
	{
		distToGround = capsuleCollider.bounds.extents.y;
	}

	private void Update()
	{
		IsGrounded();

		Jump();

		Mouvement();
	}

	//gestion des mouvement lateraux du joueur
	public void Mouvement()
	{
		//recupere les valeurs d'input via PlayerInputs
		float inputX = playerInputs.inputX;
		float inputY = playerInputs.inputY;

		//defini la direction de deplacement grace aux inputs
		Vector3 direction = new Vector3(inputX, 0f, inputY).normalized;

		if (direction.magnitude >= 0.1f)
		{
			//oriente correctement le joueur suivant son deplacement
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			//applique le mouvement
			rb.velocity = new Vector3(moveDir.x * speedMouvement, rb.velocity.y, moveDir.z * speedMouvement);
		}
	}

	//systeme de saut
	public void Jump()
	{
		//verifie l'input et le fait qu'on soit au sol
		if (playerInputs.inputJump == true && grounded)
		{
			Debug.Log("jump");
			rb.AddForce(transform.up * jumpForce,ForceMode.Impulse);
		}

	}

	//check si le joueur est au sol ou non
	public void IsGrounded()
	{
		grounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, transform.position + Vector3.down * 0.1f);
		Debug.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.down * 0.1f);
	}
} 
