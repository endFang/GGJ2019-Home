using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float moveSpeed = 3f;
	private Rigidbody2D rb2d;
	private Animator anim;
	private static readonly int speedKey = Animator.StringToHash("Speed");
	public Vector2 lastMoveDirection { get; private set; }

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			lastMoveDirection = Vector2.right;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
			transform.rotation = Quaternion.identity;
			lastMoveDirection = Vector2.left;
		}
		else
		{
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);
		}
		
		anim.SetFloat(speedKey, Mathf.Abs(rb2d.velocity.x));
	}
}