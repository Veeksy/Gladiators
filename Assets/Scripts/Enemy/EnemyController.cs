using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyData enemyData;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    private float _cooldownStart;

    [SerializeField]
    private float _health;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rangeAttack;
    [SerializeField]
    private bool meleeAttack;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private Transform ShotPoint;

    private Rigidbody2D rb;
    private PlayerData playerData;
    ArenaData arenaData;

    private float _cooldown;

    void Start()
    {
        arenaData = ArenaData.getInstance();
        enemyData = GetComponent<EnemyData>();
        playerData = PlayerData.getInstance();

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        enemyData.SetDamage(_damage);
        enemyData.SetHealthPoint(_health);
        enemyData.SetSpeed(_speed);
        enemyData.SetRangeAttack(_rangeAttack);
    }
    private void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
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
            if (meleeAttack)
            {
                IsMeleeAttack();
            }
            else
            {
                IsRangeAttack();
            }
            _cooldown += Time.deltaTime;
        }
    }

    void IsMeleeAttack()
    {
        if (Vector2.Distance(player.transform.position, rb.position) <= enemyData.GetRangeAttack())
        {
            _animator.SetBool("IsRun", false);
            if (_cooldown >= _cooldownStart)
            {
                _animator.SetTrigger("Attack");
                _cooldown = 0;
            }
        }
        else
        {
            _animator.SetBool("IsRun", true);
            Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, 4.5f * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
    }

    void IsRangeAttack()
    {
        if (Vector2.Distance(player.transform.position, rb.position) <= enemyData.GetRangeAttack())
        {
            if (_cooldown >= _cooldownStart)
            {
                _animator.SetTrigger("Attack");
                _cooldown = 0;
            }
        }
        else
        {
            _animator.SetBool("IsRun", true);
            Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, 4.5f * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
    }

    public void TakeDamage(int damage)
    {
        if (enemyData.GetHealthPoint() > 0)
        {
            _animator.SetTrigger("Hurt");
            enemyData.SetHealthPoint(enemyData.GetHealthPoint() - damage) ;
        }
        if (enemyData.GetHealthPoint() <= 0)
        {
            _animator.SetTrigger("Dead");
        }
    }

    public void IsDie()
    {
        Destroy(gameObject);
        
        arenaData.SetCountEnemy(arenaData.GetCountEnemy() - 1);
        if (arenaData.GetCountEnemy() == 0)
        {
            arenaData.NextWave();
        }
    }

    public void Attack()
    {
        playerData.TakeDamage(enemyData.GetDamage());
    }

    public void RangeAttack()
    {
        Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
    }

}
