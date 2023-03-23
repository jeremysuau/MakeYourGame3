using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CharacterController : MonoBehaviour
{
	private Rigidbody rb;
	private Collider col;
	private PlayeInputs playerInputs;

	public float speedMouvement;
	public float jumpForce;

	private Transform cam;
	private float turnSmoothVelocity;
	private float turnSmoothtime = 0.01f;
	private float distToGround;
	private bool grounded;

	private void Awake()
	{
		cam = Camera.main.transform;
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		playerInputs = GetComponent<PlayeInputs>();
	}
	private void Start()
	{
		distToGround = col.bounds.extents.y;
	}

	private void Update()
	{
		//check si le joueur est au sol ou non
		IsGrounded();

		//recupere les valeurs d'input via PlayerInputs
		float inputX = playerInputs.inputX;
		float inputY = playerInputs.inputY;

		//oriente correctement le joueur suivant se deplacement
		float targetAngle = Mathf.Atan2(inputX, inputY) * Mathf.Rad2Deg + cam.eulerAngles.y;
		float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
		transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

		//deplace le joueur a l'aide du nouvel input system
		Vector3 moveDirection = Quaternion.Euler(speedMouvement * inputX * Time.deltaTime, targetAngle, speedMouvement * inputY * Time.deltaTime) * Vector3.forward;
		rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

		//systeme de saut
		if (playerInputs.inputJump == true && grounded)
		{
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
	}

	public void IsGrounded()
	{
		//lance un rayon vers le sol pour detecter le sol
		if(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
		{
			grounded = true;
		}
		else
		{
			grounded = false; 
		}
	}
} 
