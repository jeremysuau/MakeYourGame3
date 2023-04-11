using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public LayerMask enemyLayer;

	private void OnTriggerEnter(Collider other)
	{
		Kill(other);
	}

	public void Kill(Collider other)
    {
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.GetComponentInParent<Gumpa>().Die();
		}
	}
}
