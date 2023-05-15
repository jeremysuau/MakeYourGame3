using UnityEngine;

public class Gumpa : MonoBehaviour
{
    public GameObject gfx;
    public MeshCollider collider;
    public ParticleSystem particles;
    public GameObject score;

	public void Die()
    {
        gfx.SetActive(false);
        collider.enabled = false;
        particles.Play();
		score = GameObject.FindGameObjectWithTag("GameManager");
        score.GetComponent<Score>().AddKill();
		Destroy(gameObject,1);
    }
}
