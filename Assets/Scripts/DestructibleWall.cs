using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    private Animator anim;
    private new Collider2D collider;
    
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