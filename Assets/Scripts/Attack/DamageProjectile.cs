using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageProjectile : MonoBehaviour
{
	public int damage = 1;
	public float speed = 10;
	public float flyDistance = 15;

	private float _flownDistance = 0;

	public void Shoot(Vector3 position, Quaternion rotation)
	{
		transform.position = position;
		transform.rotation = rotation;
	}

	public void Update()
	{
		float moveDistance = speed * Time.deltaTime;
		transform.position += transform.forward * moveDistance;
		
		_flownDistance += moveDistance;
		if (_flownDistance > flyDistance)
		{
			Destroy(gameObject);
		}
	}
	
	public void OnTriggerEnter(Collider collider)
	{
		Obstacle obstacle = collider.GetComponent<Obstacle>();
		if (obstacle != null)
		{
			obstacle.TakeDamage(damage);
			Destroy(gameObject);
			return;
		}

		PointGate pointGate = collider.GetComponent<PointGate>();
		if (pointGate != null)
		{
			pointGate.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}