using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isActive;
    public float time = 60;
	public TMP_Text timertext;

	void Update()
    {
        if (isActive)
        {
			time -= Time.deltaTime;
			timertext.text = time.ToString("N2");
		}
        if(time <= 0)
        {
            Debug.Log("PERDU T'ES LENT");
        }
    }
}
