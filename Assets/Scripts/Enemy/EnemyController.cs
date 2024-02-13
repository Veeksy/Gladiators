using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Slider healthBar;

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
        Debug.Log(healthBar);
        if (healthBar is not null)
        {
            healthBar.maxValue = enemyData.GetHealthPoint();
            healthBar.value = enemyData.GetHealthPoint();
        }
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
            if (!_animator.GetBool("Dead"))
            {
                _animator.SetBool("IsRun", true);
                Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, _speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
            
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
            _animator.SetBool("Dead", true);
        }
        if (healthBar is not null)
            healthBar.value = enemyData.GetHealthPoint();
    }

    public void IsDie()
    {
        Destroy(gameObject);
        if (gameObject.tag == "Enemy")
        {
            Debug.Log(arenaData.GetCountEnemy());
            arenaData.SetCountEnemy(arenaData.GetCountEnemy() - 1);
            if (arenaData.GetCountEnemy() == 0)
            {
                arenaData.NextWave();
            }
        }
        Debug.Log(arenaData.GetCountEnemy());
    }

    public void Attack()
    {
        playerData.TakeDamage(enemyData.GetDamage());
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger("Hurt");
    }

    public void RangeAttack()
    {
        Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
    }

}
