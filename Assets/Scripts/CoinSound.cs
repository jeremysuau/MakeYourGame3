using UnityEngine;

public class CoinSound : MonoBehaviour
{
	public AudioClip sound;
	public AudioSource source;

	private void OnTriggerEnter(Collider col)
	{
		if (col.transform.tag == "Player")
		{
			source.PlayOneShot(sound);
		}
	}
}
