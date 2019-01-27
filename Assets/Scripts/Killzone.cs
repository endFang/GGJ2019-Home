using UnityEngine;

public class Killzone : MonoBehaviour
{
	public GameObject player;
	private Vector3 startPos;

	private void Reset()
	{
		player = GameObject.FindWithTag("Player");
	}

	private void Start()
	{
		startPos = player.transform.position;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player")) return;
		player.transform.position = startPos;
	}
}