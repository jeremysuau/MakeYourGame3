using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	private Camera cam;

	private void Start()
	{
		cam = Camera.main;
	}
	void Update()
    {
        transform.LookAt(cam.transform.position);
    }
}
