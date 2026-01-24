using UnityEngine;

public class CycleShooter : MonoBehaviour
{
	public float shootInterval = 0.5f;
	public DamageProjectile projectilePrefab;
	
	private float _timer = 0;

	public void Update()
	{
		_timer += Time.deltaTime;
		if (_timer >= shootInterval)
		{
			_timer %= shootInterval;
			
			DamageProjectile instance = Instantiate(projectilePrefab);
			instance.Shoot(transform.position, transform.rotation);
		}
	}
}