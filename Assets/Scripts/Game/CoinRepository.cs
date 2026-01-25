using TMPro;
using UnityEngine;

public class CoinRepository : MonoBehaviour
{
	public TextMeshProUGUI coinText;
	
	private int _coinCount = 0;

	public void Start()
	{
		coinText.text = "0";
	}

	public void AddCoin(int amount)
	{
		_coinCount += amount;
		coinText.text = _coinCount.ToString();
	}
}