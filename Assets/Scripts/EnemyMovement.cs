using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rgdbdy2;
    
    public List<Transform> wayPoints = new List<Transform>();
    public float movespeed;

    private float distance;
    private float minDistance;
    private Vector3 otherColl;
    int wayPointIndex = 0;
    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[wayPointIndex].transform.position;
        minDistance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
        checkWaypoint(distance);
    }

    void checkWaypoint(float distance)
    {
        if(distance <= minDistance)
        {
            wayPointIndex = (wayPointIndex == 0) ? 1 : 0;

        }
       
    }
   
    void move()
    {
       transform.position = Vector2.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movespeed * Time.deltaTime);
    }


    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Player")){
            otherColl = other.collider.GetComponent<Rigidbody2D>().velocity;
            other.collider.GetComponent<Rigidbody2D>().velocity = -2 * otherColl + (Vector3)this.GetComponent<Rigidbody2D>().velocity;
            other.collider.GetComponent<PlayerMove>().enabled = false;
            yield return new WaitForSeconds(2);
            other.collider.GetComponent<PlayerMove>().enabled = true;
        }
        if (other.collider.CompareTag("Destroyer"))
        {
            HP--;
            this.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(.25f);
            this.GetComponent<SpriteRenderer>().enabled = true;
            if (HP == 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
