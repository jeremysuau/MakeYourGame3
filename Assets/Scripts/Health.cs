using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
	public Slider healthSlider;
	public Animator anim;

	public AudioClip[] hits;
	public AudioSource hitSource;

	private void Start()
	{
		Set();
	}

	public void TheDeathOfThePlayer()
    {
        transform.position = new Vector3(0f,12.5f,0f);
		Set();
	}

	public void Hit()
	{
		anim.Play("Hit");
		health -= 1;
		healthSlider.value = health;
        if (health <= 0)
        {
            TheDeathOfThePlayer();
		}
		int rng = Random.Range(0, hits.Length);
		hitSource.PlayOneShot(hits[rng]);
	}

	private void Set()
	{
		health = maxHealth;
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
	}
}
