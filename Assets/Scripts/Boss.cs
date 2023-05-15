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
			//StartCoroutine(Finish()); 
		}
	}

	void LevelFinish()
	{
		SceneManager.LoadScene("FinalScene");
	}

	IEnumerator Finish()
	{
		yield return new WaitForSeconds(2f);

		AsyncOperation operation = SceneManager.LoadSceneAsync("FinalScene");

		while (!operation.isDone)
		{
			yield return null; 
		}
	}
	
}