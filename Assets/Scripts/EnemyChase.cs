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
		spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
    {
        agent.SetDestination(player.transform.position);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player")
		{
			player.GetComponent<Health>().Hit();
			player.GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position).normalized * 10,ForceMode.Impulse);
			GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 10,ForceMode.Impulse);
		}
	}
}
