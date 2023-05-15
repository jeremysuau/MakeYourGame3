using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float lerpHealth;
	public Slider healthSlider;
	public Slider lerpHealthSlider;
	public GameObject manager;

	public Rigidbody playerRb;

	public Animator anim;
	public Animator animPlayer;

	public AudioClip[] hits;
	public AudioSource hitSource;

	private void Start()
	{
		Set();
	}

	private void Update()
	{
		lerpHealth = Mathf.Lerp(lerpHealth, health, 0.1f);
		lerpHealthSlider.value = lerpHealth;
	}

	public void Hit(int value)
	{
		anim.Play("Hit");
		health -= value;
		healthSlider.value = health;
        if (health <= 0)
        {
            manager.GetComponent<GameOver>().EndofGame();
			animPlayer.enabled = false;
		}
		int rng = Random.Range(0, hits.Length);
		hitSource.PlayOneShot(hits[rng]);
	}

	private void Set()
	{
		animPlayer.enabled = true;
		health = maxHealth;
		lerpHealth = maxHealth;
		healthSlider.maxValue = maxHealth;
		lerpHealthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
		lerpHealthSlider.value = maxHealth;
	}
}
