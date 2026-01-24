using System.Collections.Generic;
using UnityEngine;

public class PlayerSquad : MonoBehaviour
{
	public PlayerUnit unitPrefab;
	public int initialUnitCount = 1;
	public int maxUnitCount = 50;
	public float unitSpacing = 0.7f;

	private List<PlayerUnit> _units;

	public int unitCount
	{
		get => _units.Count;
	}
	
	private void Start()
	{
		_units = new List<PlayerUnit>(initialUnitCount);
		AddUnits(initialUnitCount);
	}

	private void AddUnits(int count)
	{
		if (_units.Count + count > maxUnitCount)
		{
			count = maxUnitCount - _units.Count;
		}
		
		for (int i = 0; i < count; i++)
		{
			PlayerUnit unit = Instantiate(unitPrefab, transform);
			unit.Initialize(this);
			_units.Add(unit);
			unit.transform.localPosition = CalculateUnitLocalPosition(i);	
		}
	}

	private void RepositionUnits()
	{
		for (int i = 0; i < _units.Count; i++)
		{ 
			PlayerUnit unit = _units[i];
			unit.transform.localPosition = CalculateUnitLocalPosition(i);
		}
	}

	private Vector3 CalculateUnitLocalPosition(int index)
	{
		int i = index;
		int y = 0;
		int x;
		int unitCountInCurrentLine = 1;
		while (true)
		{
			if (unitCountInCurrentLine > i)
			{
				x = i - y;
				break;
			}
			i -= unitCountInCurrentLine;
			unitCountInCurrentLine += 2;
			y++;
		}
		return new Vector3(x, 0, -y) * unitSpacing;
	}
	
	public void UnitDied(PlayerUnit unit)
	{
		_units.Remove(unit);
		Destroy(unit.gameObject);
		
		RepositionUnits();
	}

	public void AddPoint(int point)
	{
		AddUnits(point);
	}
}