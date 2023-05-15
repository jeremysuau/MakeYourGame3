using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public TMP_Text coinsText;
	public TMP_Text killsText;
	public int coins = 0;
	public int kills = 0;

	private void Start()
	{
		coinsText.text = coins.ToString("N0");
		
	}

	public void AddCoin(int value)
	{
		coins += value;
		coinsText.text = coins.ToString("N0");
		PlayerPrefs.SetInt("CoinValue", coins);
	}

	public void AddKill()
	{
		kills += 1;
		killsText.text = kills.ToString("N0");
		PlayerPrefs.SetInt("KillValue", kills);
	}
}