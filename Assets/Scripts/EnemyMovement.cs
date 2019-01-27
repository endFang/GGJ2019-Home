using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    public List<Transform> wayPoints = new List<Transform>();
    private Transform targetWaypoint;
    private float minDistance;
    public float movespeed;
    public Vector2 maxDistance;
    private float distance;
    int wayPointIndex;


    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex = 0;
        targetWaypoint = wayPoints[wayPointIndex];
        minDistance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        distance = Vector2.Distance(transform.position, targetWaypoint.position);
        Debug.Log("Distance" + distance);

        checkWayPoint(distance);
    }

    void checkWayPoint(float distance)
    {
        if(distance <= minDistance)
        {
            wayPointIndex = wayPointIndex == 0 ? 1 : 0;  
            targetWaypoint = wayPoints[wayPointIndex];
        }
        
    }
    void move()
    {
       transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, movespeed * Time.deltaTime);
    }
}
