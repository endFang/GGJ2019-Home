using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomControls : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    private Vector2 velocityX;
    private Vector2 velocityX2;
    public Vector3 velocityY;
    public float speedx;
    public float speedy;
    bool ground = false;

    // Start is called before the first frame update
    void Start()
    {
        rgdbdy2 = GetComponent<Rigidbody2D>();
        velocityX = new Vector2(speedx, 0.0f);
        velocityX2 = new Vector2(-speedx, 0.0f);
        velocityY = new Vector3(0.0f, speedy, 0.0f);

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
            //if(ground == true)
            //{
               rgdbdy2.AddForce(velocityY);//jump
            //}
            ground = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
    }
    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rgdbdy2.velocity = new Vector3(1, rgdbdy2.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgdbdy2.velocity = new Vector3(1, rgdbdy2.velocity.y, 0);
        }
    }
}
