using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
	public GameObject gfx;
	public MeshCollider collider;
	public ParticleSystem particles;
	public GameObject score;
	public int health;

	private void Start()
	{
		health = 3;
	}

	public void Die()
	{
		if (health > 0)
		{
			health -= 1;
		}
		else
		{
			gfx.SetActive(false);
			collider.enabled = false;
			particles.Play();
			score.GetComponent<Score>().AddKill();
			Destroy(gameObject, 1);
			LevelFinish();
		}
	}

	void LevelFinish()
	{
		SceneManager.LoadScene("FinalScene");
	}

}