using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class AutoFocus : MonoBehaviour
{
	public Transform player;
	public GameObject globalVolume;
	public Transform cam;

	private void Start()
	{
		cam = Camera.main.transform;
	}

	private void Update()
	{
		float distoffield = Vector3.Distance(player.transform.position, cam.position);
		Volume volumeProfile = globalVolume.GetComponent<Volume>();
		DepthOfField depthOfField;
		if (volumeProfile.profile.TryGet(out depthOfField))
		{
			depthOfField.focusDistance.value = distoffield;
		}
	}
}
