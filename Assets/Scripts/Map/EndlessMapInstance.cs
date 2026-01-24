using UnityEngine;
using UnityEngine.Events;

public class EndlessMapInstance : MonoBehaviour
{
	public UnityEvent onReset;

	public void Reset()
	{
		onReset.Invoke();
	}
}