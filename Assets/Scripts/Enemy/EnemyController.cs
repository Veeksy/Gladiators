using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyData enemyData;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform player;

    private Rigidbody2D rb;
    private PlayerData playerData;
    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        playerData = PlayerData.getInstance();

        enemyData.SetHealthPoint(100);
        enemyData.SetDamage(5);

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3 (0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        if (playerData.GetHealthPoint() > 0)
        {
            if (Vector2.Distance(player.position, rb.position) <= enemyData.GetRangeAttack() + 2f)
            {
                _animator.SetTrigger("Attack");
            }
            else
            {
                _animator.SetBool("IsRun", true);
                Vector2 target = new Vector2(player.position.x, player.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, 4.5f * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _animator.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        playerData.TakeDamage(enemyData.GetDamage());
    }


}
