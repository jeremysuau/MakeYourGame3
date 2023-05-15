using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
	public int coins;
	public int kills;
	public float time;
	public float point;
	public TMP_Text coinsText;
	public TMP_Text killsText;
	public TMP_Text timeText;
	public TMP_Text pointText;

	private void Start()
	{
		coins = PlayerPrefs.GetInt("CoinValue", 1);
		kills = PlayerPrefs.GetInt("KillValue", 2);
		time = PlayerPrefs.GetFloat("TimeValue", 3);

		point = coins * kills * time;

		coinsText.text = coins.ToString("N0");
		killsText.text = kills.ToString("N0");
		timeText.text = time.ToString("N2");
		pointText.text = point.ToString("N0");
	}
}
