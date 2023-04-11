using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gb;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        float rng = Random.Range(0f, 1f);
        if(rng < 0.35f)
        {
            return;
        }
        else if(rng >= 0.35f && rng < 0.65f)
        {
            Instantiate(gb[0], transform.position, Quaternion.identity);
        }
        else if(rng >= 0.65f && rng < 0.85f)
        {
			Instantiate(gb[1], transform.position, Quaternion.identity);
		}
        else if(rng >= 0.85f)
        {
            Instantiate(gb[2], transform.position, Quaternion.identity);
        }
        
    }
}
