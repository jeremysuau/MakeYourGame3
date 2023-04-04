using UnityEngine;

public class CoinSound : MonoBehaviour
{
	public AudioClip sound;
	public AudioSource source;

	private void OnTriggerEnter()
	{
		source.PlayOneShot(sound);
		Debug.Log("PlayCoinSound");
	}
}
