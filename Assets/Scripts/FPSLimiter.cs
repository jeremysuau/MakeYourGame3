using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
	private void Start()
	{
		Application.targetFrameRate = 120;
	}
}
