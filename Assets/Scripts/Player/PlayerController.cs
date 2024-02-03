using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    [SerializeField]
    private Animator animator;

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
            Flip();
        }
        else if (direction.x > 0 && !right)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * playerData.GetSpeed() * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
