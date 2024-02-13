using Unity.VisualScripting;
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
    public Transform _attack;

    private Vector2 direction;
    private bool right = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerData = PlayerData.getInstance();

        playerData.SetHealthPoint(_maxHealth);
        playerData.SetDamage(_damage);
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

        if (direction.x < 0 && right)
            Flip();
        else if (direction.x > 0 && !right)
            Flip();

        if (playerData.GetHealthPoint() < 1)
        {
            animator.SetTrigger("Dead");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * playerData.GetSpeed() * playerData.GetBonusSpeed() * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        _attack.Rotate(0f, 180f, 0f);
    }

    public void Die()
    {
        Time.timeScale = 0;
    }

}
