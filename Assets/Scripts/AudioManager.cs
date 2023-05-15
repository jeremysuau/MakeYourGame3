using UnityEngine;
using UnityEngine.ProBuilder;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSource;

    public void MakeSound(Transform pos, AudioClip clip)
    {
		GameObject source = Instantiate(audioSource, pos);
        source.GetComponent<AudioSource>().PlayOneShot(clip);
	}
}
