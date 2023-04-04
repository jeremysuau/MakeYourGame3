using System.Collections;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioSource footstepSource;

	public void EarItRunning()
	{
		int rng = Random.Range(0, footsteps.Length);
		footstepSource.PlayOneShot(footsteps[rng]);
	}
}
