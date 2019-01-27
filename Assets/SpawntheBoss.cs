using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawntheBoss : MonoBehaviour
{
    Vector3 SpawnPoint;
    public GameObject Boss;
    GameObject Spawned;
    public GameObject Location1;
    public GameObject Location2;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = new Vector3(16, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Spawn");
                Spawned = Instantiate(Boss, SpawnPoint, Quaternion.identity);
                Spawned.GetComponent<EnemyMovement>().wayPoints[0] = Location1.transform;
                Spawned.GetComponent<EnemyMovement>().wayPoints[1] = Location2.transform;
                Destroy(gameObject);
            }
        }
    }
}
