using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public GameObject projectilePrefab;
	public Vector3 spawnOffset;
	public KeyCode keybind = KeyCode.Q;
	private Rigidbody2D rb2d;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(keybind))
		{
			GameObject projectile = Instantiate(projectilePrefab);

			projectile.transform.position = transform.position + spawnOffset;
			projectile.GetComponent<Rigidbody2D>().velocity = Vector2.right;
		}
	}
}