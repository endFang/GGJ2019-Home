using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    private Animator anim;
    private Collider2D collider;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Destroyer"))
        {
            anim.enabled = true;
            collider.enabled = false;
        }
    }

    public void OnBreakEnd()
    {
        Destroy(gameObject);
    }
}
