using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerUnit : MonoBehaviour
{
	public int characterHealth = 1;
	
	private PlayerSquad _playerSquad;

	public void Initialize(PlayerSquad playerSquad)
	{
		_playerSquad = playerSquad;
	}
	
	public void TakeDamage(int damage)
	{
		characterHealth -= damage;
		
		if (characterHealth <= 0)
		{
			_playerSquad.UnitDied(this);
		}
	}

	public void GetPoint(int point)
	{
		_playerSquad.AddPoint(point);
	}
}