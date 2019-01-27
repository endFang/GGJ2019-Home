using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public KeyCode keybind = KeyCode.LeftAlt;
	public GameObject projectilePrefab;
	public Vector2 spawnOffset;
	public float projectileSpeed;

	private PlayerMove move;

	private void Start()
	{
		move = GetComponent<PlayerMove>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(keybind))
		{
			Vector3 spawnPos = transform.position + (Vector3) (spawnOffset * (move.lastMoveDirection + Vector2.up));
			GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = move.lastMoveDirection * projectileSpeed;
		}
	}
}