using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyChase : MonoBehaviour
{
    private GameObject player;
    private Transform spawn;
	private NavMeshAgent agent;
	private Vector3 nextPos;
	public float range;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		nextPos = transform.position;

		InvokeRepeating("Chase", 0f, 1f);
	}

	public Vector3 RandomPoint(Vector3 startPoint, float range)
	{

		Vector3 dir = Random.insideUnitSphere * range;
		dir += startPoint;
		NavMeshHit hit;
		Vector3 finalPos = Vector3.zero;
		if(NavMesh.SamplePosition(dir, out hit, range, 1))
		{
			finalPos = hit.position;
		}
		return finalPos;
	}

	private void Chase()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.gameObject.CompareTag("Player"))
			{
				agent.speed = 15;
				agent.SetDestination(hitCollider.transform.position);
				return;
			}
			else
			{
				agent.speed = 2;
				if (Vector3.Distance(nextPos, transform.position) <= 1.5f)
				{
					nextPos = RandomPoint(transform.position, 10f);
					agent.SetDestination(nextPos);
				}
			}
		}
	}
}
