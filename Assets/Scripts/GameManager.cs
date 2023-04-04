using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool active;
	public float value;
	private void Update()
	{
		if (active)
		{
			//incremente le chrono
			value += Time.deltaTime;
		}
	}
	public void ActiveChrono()
	{
		if (active)
		{
			active = false;
		}
		else
		{
			active = true;
		}
	}
}
