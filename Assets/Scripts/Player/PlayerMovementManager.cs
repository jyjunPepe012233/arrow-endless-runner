using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
	public float moveSpeed = 3f;
	public float moveRange = 3f;

	private void Update()
	{
		float input = Input.GetAxisRaw("Horizontal");
		Vector3 movement = Vector3.right * (input * moveSpeed);
		transform.position += movement * Time.deltaTime;

		Vector3 position = transform.position;
		position.x = Mathf.Clamp(position.x, -moveRange, moveRange);
		transform.position = position;
	}
}