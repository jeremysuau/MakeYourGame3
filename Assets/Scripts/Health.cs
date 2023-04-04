using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
	public Slider healthSlider;

	private void Start()
	{
		health = maxHealth;
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
	}

	public void TheDeathOfThePlayer()
    {
        Debug.Log("PERDU T'ES MORT");
    }

	public void Hit()
	{
        health -= 1;
		healthSlider.value = health;
        if (health <= 0)
        {
            TheDeathOfThePlayer();
		}
	}
}
