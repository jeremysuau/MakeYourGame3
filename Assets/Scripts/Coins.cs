using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Coins : MonoBehaviour
{
    public float VerticalBobFrequency = 1f;
    public float BobbingAmount = 1f;
    public float RotatingSpeed = 180f;
    Vector3 startPosition;
    private MeshRenderer renderer;
	private Collider col;

	public int value;
    public Score coinsValue;


	private void Start()
	{
        startPosition = transform.position;
		renderer = GetComponent<MeshRenderer>();
		col = GetComponent<SphereCollider>();
	}

	void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
        transform.position = startPosition + Vector3.up * bobbingAnimationPhase;

        // Handle rotating
        transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
    }

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Player")
		{
			coinsValue.AddCoin(value);
			renderer.enabled = false;
			col.enabled = false;
			Destroy(gameObject,1);
		}
	}

}
