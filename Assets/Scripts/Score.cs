using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public TMP_Text coinsText;
	public int coins = 0;

	private void Start()
	{
		coinsText.text = coins.ToString("N0");
	}

	public void AddCoin(int value)
	{
		coins += value;
		coinsText.text = coins.ToString("N0");
	}
}