using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float moveSpeed = 3f;
	private Rigidbody2D rb2d;
	public Vector2 lastMoveDirection { get; private set; }

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
			lastMoveDirection = Vector2.right;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
			lastMoveDirection = Vector2.left;
		}
		else
		{
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);
		}
	}
}