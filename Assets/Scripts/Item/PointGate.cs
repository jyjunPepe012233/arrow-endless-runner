using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointGate : Item, IDamageableItem
{
	public int initialMinPoint = -15;
	public int initialMaxPoint = -5;

	public TextMeshPro pointText;

	private int _currentPoint;
	
	public override void Initialize()
	{
		_currentPoint = GetRandomPoint();
		UpdateHealthText();
	}

	private int GetRandomPoint()
	{
		return Random.Range(initialMinPoint, initialMaxPoint + 1);
	}

	private void UpdateHealthText()
	{
		pointText.text = _currentPoint.ToString();
		if (_currentPoint > 0)
		{
			pointText.color = Color.blue;
		}
		else if (_currentPoint < 0)
		{
			pointText.color = Color.red;
		}
		else
		{
			pointText.color = Color.gray;
		}
	}

	protected override void OnHitPlayerUnit(PlayerUnit playerUnit)
	{
		if (_currentPoint > 0)
		{
			playerUnit.GetPoint(_currentPoint);
		}

		if (_currentPoint < 0)
		{
			playerUnit.TakeDamage(-_currentPoint);
		}
			
		Destroy(gameObject);
	}

	public void TakeDamage(int damage)
	{
		_currentPoint += 1;
		UpdateHealthText();
	}
}