using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	private void OnTriggerEnter()
	{
		SceneManager.LoadScene("FinalScene");
	}
}
