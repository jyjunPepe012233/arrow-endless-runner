using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : Item
{
	public int initialMinHealth = 5;
	public int initialMaxHealth = 15;

	public TextMeshPro healthText;

	public GameObject coinPrefab;

	private int _currentHealth;
	private bool _isBroken = false;
	
	public override void Initialize()
	{
		_currentHealth = GetRandomHealth();
		UpdateHealthText();
	}

	private int GetRandomHealth()
	{
		return Random.Range(initialMinHealth, initialMaxHealth + 1);
	}

	private void UpdateHealthText()
	{
		healthText.text = _currentHealth.ToString();
	}

	protected override void OnHitPlayerUnit(PlayerUnit playerUnit)
	{
		int temp = playerUnit.characterHealth; 
		playerUnit.TakeDamage(_currentHealth);
		TakeDamage(temp);
	}

	public void TakeDamage(int damage)
	{
		if (_currentHealth <= damage)
		{
			_currentHealth = 0;
			UpdateHealthText();
			Break();
			return;
		}

		_currentHealth -= damage;
		UpdateHealthText();
	}

	private void Break()
	{
		if (_isBroken) return;
		// 아래 Break 함수가 실행된 후 Destroy가 실제로 반영되기까지 1프레임의 시간이 존재함.
		// 그 시간 동안 TakeDamage가 여러번 호출될 수 있으므로, _isBroken 플래그를 통해 이미 부서졌는지 확인
		// 디버깅 과정으로 커리큘럼에 포함할 것

		_isBroken = true;
		
		Instantiate(coinPrefab, transform.position, transform.rotation, transform.parent);
		Destroy(gameObject);
	}
}