using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
	public float moveRange = 3f;

	private void Update()
	{
		if (Input.touchCount == 0)
		{
			return;
		}
		
		Touch touch = Input.GetTouch(0);
		Ray ray = Camera.main.ScreenPointToRay(touch.position);
		
		Debug.DrawRay(ray.origin, ray.direction, Color.red, 1);
		
		if (Physics.Raycast(ray, out RaycastHit hitInfo, 50, LayerMask.GetMask("Ground")))
		{
			Vector3 position = Vector3.zero;
			position.x = hitInfo.point.x;
			position.x = Mathf.Clamp(position.x, -moveRange, moveRange);
			transform.position = position;
		}
	}
}