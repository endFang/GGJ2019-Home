using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	public float jumpStrength = 7f;
	public Collider2D feetCollider;
	public LayerMask groundMask;
	public bool grounded { get; private set; }
	private Rigidbody2D rb2d;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space) && grounded)
		{
			rb2d.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
			grounded = false;
		}
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground") && !grounded)
		{
			Bounds feetBounds = feetCollider.bounds;
			var feetPosition = new Vector2(transform.position.x, feetBounds.min.y);
			
			RaycastHit2D hit = Physics2D.BoxCast(
				feetPosition,
				feetBounds.size,
				0,
				Vector2.down,
				0.1f,
				groundMask
			);

			if (hit.collider != null && hit.collider.CompareTag("Ground"))
			{
				grounded = true;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			grounded = false;
		}
	}
}