using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;

	void LateUpdate()
	{
		Transform t = transform;
		Vector3 newPosition = player.position;
		newPosition.z = t.position.z;

		t.position = newPosition;
	}
}