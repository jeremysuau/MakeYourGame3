using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
	private MeshRenderer mesh;
	private Rigidbody rb;

	private void Start()
	{
		mesh = GetComponent<MeshRenderer>();
		rb = GetComponent<Rigidbody>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			rb.constraints = RigidbodyConstraints.None;
		}
	}

}
