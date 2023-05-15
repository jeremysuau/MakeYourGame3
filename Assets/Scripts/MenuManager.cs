using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject loadingScreen;
	public Slider slider;
	public Animator transition;

    public void StartGame()
    {
		StartCoroutine(LoadAsynchronously("MainScene"));
    }

	public void Quit()
	{
		Application.Quit();
	}

	IEnumerator LoadAsynchronously(string scenName)
	{
		transition.Play("fade");

		yield return new WaitForSeconds(0.5f);

		AsyncOperation operation = SceneManager.LoadSceneAsync(scenName);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress /0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
