using UnityEngine;

public class Ding : MonoBehaviour
{
    public AudioClip clip;
	public AudioManager manager;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Piece"))
		{
			manager.MakeSound(transform, clip);
		}
	}
}
