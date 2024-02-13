using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
        {
            animator.SetTrigger("Expl");
            var enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        if (collision.CompareTag("Ground"))
        {
            animator.SetTrigger("Expl");
        }
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }


}
