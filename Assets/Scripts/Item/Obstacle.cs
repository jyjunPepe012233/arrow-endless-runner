using TMPro;
using UnityEngine;

public class Obstacle : Item, IDamageableItem
{
	public int initialMinHealth = 5;
	public int initialMaxHealth = 15;

	public TextMeshPro healthText;

	private int _currentHealth;
	
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
		Destroy(gameObject);
	}
}