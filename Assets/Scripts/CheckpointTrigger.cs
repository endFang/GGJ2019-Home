using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var playerRespawn = other.GetComponent<PlayerRespawn>();

		if (playerRespawn == null) return;

		playerRespawn.checkpointPosition = transform.position;
	}
}