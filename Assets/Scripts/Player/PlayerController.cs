using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 direction;
    public Animator animator;
    private PlayerData playerData;
    private bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerData = PlayerData.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizontalMove", 
            Mathf.Abs(direction.x != 0 ? direction.x : direction.y));

        if (direction.x < 0 && right)
        {
            Debug.Log("left");
            Flip();
        }
        else if (direction.x > 0 && !right)
        {
            Flip();
            Debug.Log("Right");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * 10 * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
