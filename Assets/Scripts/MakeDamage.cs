using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
	public int damage;
	public bool isLava;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player")
		{
			PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
			playerController.isTakingDamage = true;
			collision.gameObject.GetComponent<Health>().Hit(damage);
			if(!isLava)
			{
				Debug.Log(collision.gameObject.name);
				//creer un jump pour cause de collision avec un enemi
				collision.gameObject.GetComponent<Rigidbody>().AddForce(800f * transform.forward,ForceMode.Impulse);
			}
			else
			{
				//creer un jump pour cause de collision avec la lave
				collision.gameObject.GetComponent<Rigidbody>().AddForce(1f * transform.up, ForceMode.Impulse);
			}
			StartCoroutine(playerController.TakingDamage());
		}
	}
}
