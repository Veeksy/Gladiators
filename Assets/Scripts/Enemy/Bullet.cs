using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    PlayerData playerData;

    [SerializeField]
    private LayerMask WhatIsSolid;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    private Vector2 target;
    [SerializeField]
    private float _damage;

    private void Start()
    {
        playerData = PlayerData.getInstance();
        player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform.position;
    }

    private void Update()
    {
        //rb.MovePosition(rb.position + playerTransform * 1.1f * Time.fixedDeltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, 10f * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            animator.SetTrigger("Explotion");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerData.TakeDamage(_damage);

        }
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
