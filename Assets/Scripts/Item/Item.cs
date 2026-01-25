using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public abstract void Initialize();

	public void OnTriggerEnter(Collider collider)
	{
		PlayerUnit playerUnit = collider.GetComponent<PlayerUnit>();
		if (playerUnit != null)
		{
			OnHitPlayerUnit(playerUnit);
		}
	}

	protected abstract void OnHitPlayerUnit(PlayerUnit playerUnit);
}