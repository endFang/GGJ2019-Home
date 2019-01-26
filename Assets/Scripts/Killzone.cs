using UnityEngine;

public class Killzone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var playerRespawn = other.GetComponent<PlayerRespawn>();

		if (playerRespawn == null) return;

		playerRespawn.Kill();
	}
}