using System.Collections.Generic;
using UnityEngine;

public class EndlessMap : MonoBehaviour
{ 
	public int mapCount = 3;
	public EndlessMapInstance prefab;
	public float mapLength = 30f;
	public float scrollSpeed = 0.2f;
	
	private List<EndlessMapInstance> _maps;
	
	private float _currentScrolling = 0;
	
	private void Start()
	{
		_maps = new List<EndlessMapInstance>(mapCount);
		for (int i = 0; i < mapCount; i++)
		{
			EndlessMapInstance instance = Instantiate(prefab, transform);
			_maps.Add(instance);
			instance.Reset();
		}
	}

	private void Update()
	{
		_currentScrolling += Time.deltaTime * scrollSpeed;
		if (_currentScrolling > 1f)
		{
			_currentScrolling %= 1f;
			DequeueAndEnqueueInstance();
		}
		
		for (int i = 0; i < _maps.Count; i++)
		{
			EndlessMapInstance bg = _maps[i];
			float position = i * mapLength + (1 - _currentScrolling) * mapLength - mapLength;
			bg.transform.position = Vector3.forward * position;
		}
	}

	private void DequeueAndEnqueueInstance()
	{
		EndlessMapInstance instance = _maps[0];
		_maps.RemoveAt(0);
		_maps.Add(instance);
		instance.Reset();
	}
}
