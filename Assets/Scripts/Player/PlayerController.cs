using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _maxMana;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    

    private PlayerData playerData;
    private Rigidbody2D rb;
    
    private Vector2 direction;
    private bool right = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerData = PlayerData.getInstance();

        playerData.SetHealthPoint(_maxHealth);
        playerData.SetMaxHealthPoint(_maxHealth);
        playerData.SetMaxManaPoint(_maxMana);
        playerData.SetManaPoint(_maxMana);
        playerData.SetSpeed(_speed);
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizontalMove", 
            Mathf.Abs(direction.x != 0 ? direction.x : direction.y));

        if (Input.GetKeyDown(KeyCode.Space) && (direction.x != 0 || direction.y != 0) && playerData.GetManaPoint() >= 20)
        {
            animator.SetTrigger("Roll");
            playerData.SetSpeed(playerData.GetSpeed() * 0.45f);
            playerData.SetManaPoint(playerData.GetManaPoint() - 20);
            Invoke("ReturnSpeed", 0.5f);
        }

        if (direction.x < 0 && right)
            Flip();
        else if (direction.x > 0 && !right)
            Flip();

        if (playerData.GetManaPoint() < playerData.GetMaxManaPoint())
            playerData.SetManaPoint(playerData.GetManaPoint() + Time.deltaTime * 4f);
    }

    private void ReturnSpeed()
    {
        playerData.SetSpeed(playerData.GetBonusSpeed());
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
