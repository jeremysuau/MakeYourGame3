using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isActive;
    public float time = 60;
	public TMP_Text timertext;
	public GameObject manager;

	void Update()
    {
        if (isActive)
        {
			time -= Time.deltaTime;
            timertext.text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
			PlayerPrefs.SetFloat("TimeValue", time);
		}
        if(time <= 0)
        {
            manager.GetComponent<GameOver>().EndofGame();
        }
    }
}
