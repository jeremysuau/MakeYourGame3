using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private GameObject player;
    private Transform spawn;
	private NavMeshAgent agent;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
    {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.gameObject.CompareTag("Player"))
			{
				agent.speed = 15;
				agent.SetDestination(hitCollider.transform.position);
			}
			else
			{
				agent.speed = 2;
				if (agent.remainingDistance <= agent.stoppingDistance) 
				{
					Vector3 point;
					if (RandomPoint(transform.position, 7, out point)) 
					{
						Debug.DrawRay(point, Vector3.up, Color.red, 1.0f); 
						agent.SetDestination(point);
					}
				}
			}
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player")
		{
			player.GetComponent<Health>().Hit();
		}
	}

	bool RandomPoint(Vector3 center, float range, out Vector3 result)
	{

		Vector3 randomPoint = center + Random.insideUnitSphere * range; 
		NavMeshHit hit;
		if (NavMesh.SamplePosition(randomPoint, out hit, 8.0f, NavMesh.AllAreas)) 
		{
			result = hit.position;
			return true;
		}

		result = Vector3.zero;
		return false;
	}
}
