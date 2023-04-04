using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kill();
	}

    public void Kill()
    {
		bool trigger = Physics.CheckSphere(transform.position, 0.1f, enemyLayer, QueryTriggerInteraction.Collide);
        if (trigger)
        {
            Debug.Log("kill");
        }
	}
}
