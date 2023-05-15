using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panelGameOver;
    public GameObject panelHit;
    public void EndofGame()
    {
        Time.timeScale = 0.5f;
        panelGameOver.SetActive(true);
		panelHit.SetActive(false);
        GetComponent<HideMouse>().enabled = false;
    }

	public void Retry()
	{
		Time.timeScale = 1f;
        panelGameOver.SetActive(false);
		panelHit.SetActive(true);
		GetComponent<HideMouse>().enabled = true;
		SceneManager.LoadScene("MainScene");
	}

    public void Quit()
    {
        Application.Quit();
    }
}
