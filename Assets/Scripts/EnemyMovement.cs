using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    
    Transform[] wayPoints;
    public float movespeed;
    public Vector2 maxDistance;

    int wayPointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
       // transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movespeed * Time.deltaTime);
    }
}
