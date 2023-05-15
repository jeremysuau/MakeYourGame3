using System.Collections;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioSource footstepSource;

	public GameObject particles;

	public void EarItRunning()
	{
		int rng = Random.Range(0, footsteps.Length);
		footstepSource.PlayOneShot(footsteps[rng]);
	}

	public void SeeItRunning()
	{
		GameObject clone = Instantiate(particles, transform.position, Quaternion.identity);
		Destroy(clone, 1);
	}
}
