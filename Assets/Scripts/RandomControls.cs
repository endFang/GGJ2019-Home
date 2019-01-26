using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomControls : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    public float jumpForce;
    public float moveHorizontal;
    public Collider2D playerfeetCollider;
    private Vector3 velocityY;
    private int layerMask;
    public Animator animator;

    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rgdbdy2 = GetComponent<Rigidbody2D>();
        velocityY = new Vector3(0.0f, jumpForce, 0.0f);
        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    
    }
    void jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("IsJump", true);
            rgdbdy2.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode2D.Impulse);//jump
            isGrounded = false;
            
        }
    }

   void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground")){
            Vector2 feetPosition = new Vector2(this.transform.position.x, playerfeetCollider.bounds.min.y);
            RaycastHit2D feetSensor = Physics2D.Raycast(feetPosition, Vector2.down, 0.1f, layerMask);
           
            if (feetSensor && feetSensor.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                animator.SetBool("IsJump", false);
            }
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")){
            isGrounded = false;
        }
    }
    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rgdbdy2.velocity = new Vector3(moveHorizontal, rgdbdy2.velocity.y, 0);
            animator.SetFloat("Speed", moveHorizontal);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgdbdy2.velocity = new Vector3(-moveHorizontal, rgdbdy2.velocity.y, 0);
            animator.SetFloat("Speed", moveHorizontal);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
