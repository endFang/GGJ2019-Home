﻿using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	public KeyCode keybind = KeyCode.Space;
	public float jumpStrength = 7f;
	public Collider2D feetCollider;
	public LayerMask groundMask;
	public bool grounded { get; private set; }
    public bool hasWallJumped;
    public bool canWallJump;
    
	private Rigidbody2D rb2d;
	private Animator anim;
	private static readonly int isJumpKey = Animator.StringToHash("IsJump");

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        hasWallJumped = false;
    }

	private void Update()
	{
		if (Input.GetKeyDown(keybind) && grounded)
		{
			rb2d.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
			grounded = false;
		}
		
		anim.SetBool(isJumpKey, !grounded);
	}

	public void EnableWallJump()
	{
		canWallJump = true;
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
                hasWallJumped = false;
            }
            else if (canWallJump && !hasWallJumped && Input.GetKeyDown(keybind))
            {
                rb2d.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
                hasWallJumped = true;
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