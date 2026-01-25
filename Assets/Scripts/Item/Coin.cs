using UnityEngine;

public class Coin : Item
{
	public override void Initialize()
	{
	}

	protected override void OnHitPlayerUnit(PlayerUnit playerUnit)
	{
		CoinRepository coinRepository = FindObjectOfType<CoinRepository>();
		coinRepository.AddCoin(1);
		Destroy(gameObject);
	}
}