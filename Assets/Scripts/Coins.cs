using UnityEngine;

public class Coins : MonoBehaviour
{
    public float VerticalBobFrequency = 1f;
    public float BobbingAmount = 1f;
    public float RotatingSpeed = 180f;
    Vector3 startPosition;


	private void Start()
	{
        startPosition = transform.position;
    }

	void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
        transform.position = startPosition + Vector3.up * bobbingAnimationPhase;

        // Handle rotating
        transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
    }

}
