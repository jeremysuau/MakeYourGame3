using UnityEngine;

public class KillEnemy : MonoBehaviour
{
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Boss"))
		{
			transform.GetComponentInParent<Rigidbody>().AddForce(1200f * transform.up, ForceMode.Impulse);
			col.GetComponentInParent<Boss>().Die();

		}else if (col.gameObject.CompareTag("Enemy"))
		{
			transform.GetComponentInParent<Rigidbody>().AddForce(500f * transform.up, ForceMode.Impulse);
			col.GetComponentInParent<Gumpa>().Die();
		}
	}
}
