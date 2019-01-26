using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomControls : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    public float jumpForce;
    public float moveHorizontal;

    private Vector3 velocityY;

    bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rgdbdy2 = GetComponent<Rigidbody2D>();
        velocityY = new Vector3(0.0f, jumpForce, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    
    }
    void jump()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            { 
               rgdbdy2.AddForce(velocityY);//jump
            }
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log(collision.collider.name);
    }
    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rgdbdy2.velocity = new Vector3(moveHorizontal, rgdbdy2.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgdbdy2.velocity = new Vector3(-moveHorizontal, rgdbdy2.velocity.y, 0);
        }
    }
}
