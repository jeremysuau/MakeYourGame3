using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerInputs playerInputs;
	private CharacterController charController;
	private AnimatorManager animManager;

	[Header ("Gameplay")]
	public float speedMouvement;
	public float jumpForce;

	[Header("Constants")]
	public float gravity = 9.81f;
	public float mass = 10;
	public float velocityY;
	private float cooldownGrounded = 0.1f;

	private Transform cam;
	private float turnSmoothVelocity;
	private float turnSmoothtime = 0.1f;
	public bool grounded;

	private void Awake()
	{
		cam = Camera.main.transform;
		playerInputs = GetComponent<PlayerInputs>();
		charController = GetComponent<CharacterController>();
		animManager = GetComponent<AnimatorManager>();
	}

	private void Update()
	{
		IsGrounded();

		Fall();

		Jump();

		Mouvement();

		charController.Move(transform.up * velocityY * Time.deltaTime);
	}
	//application de la gravité
	public void Fall()
	{
		if (grounded)
		{
			velocityY = -1;
		}
		else
		{
			Debug.Log("fall");
			velocityY -= gravity * mass * Time.deltaTime;
		}
	}

	//gestion des mouvement lateraux du joueur
	public void Mouvement()
	{
		//recupere les valeurs d'input via PlayerInputs
		float inputX = playerInputs.inputX;
		float inputY = playerInputs.inputY;

		//deplace le joueur a l'aide du nouvel input system
		Vector3 direction = new Vector3(inputX, 0f, inputY).normalized;
		if (direction.magnitude >= 0.1f)
		{
			if (grounded)
			{
				animManager.SetAnimatorToRun();
			}
			//oriente correctement le joueur suivant son deplacement
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			charController.Move(moveDir * speedMouvement * Time.deltaTime);
		}
		else
		{
			if (grounded)
			{
				animManager.SetAnimatorToIdle();
			}
		}
	}

	//systeme de saut
	public void Jump()
	{
		//verifie l'input et le fait qu'on soit au sol
		if (playerInputs.inputJump == true && grounded)
		{
			Debug.Log("jump");
			velocityY = jumpForce;
		}
		if( velocityY > 0.1f)
		{
			animManager.SetAnimatorToJump();
		}
	}

	//check si le joueur est au sol ou non
	public void IsGrounded()
	{
		//utilise le CharacterController pour check la collision avec le sol
		/*
		if(charController.isGrounded)
		{
			cooldownGrounded = 0.1f;
		}
		else
		{ 
			cooldownGrounded -= Time.deltaTime;
		}
		*/
		if(charController.isGrounded)
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
		
	}
} 
