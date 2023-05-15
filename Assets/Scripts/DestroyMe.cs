using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float timeBeforeDestroy;

	private void Update()
	{
		if(timeBeforeDestroy == 0) 
		{ 
			Destroy(gameObject);
		}
		else
		{
			timeBeforeDestroy -= Time.deltaTime;
		}
	}
}
