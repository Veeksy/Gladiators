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

    private Rigidbody2D rb;
    private PlayerData playerData;
    public HealthBar healthBar;

    private float _cooldown;

    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        playerData = PlayerData.getInstance();
        //player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        enemyData.SetDamage(_damage);
        enemyData.SetHealthPoint(_health);
        enemyData.SetSpeed(_speed);
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
            if (Vector2.Distance(player.transform.position, rb.position) <= enemyData.GetRangeAttack() + 2f)
            {
                if (_cooldown >= _cooldownStart)
                {
                    _animator.SetTrigger("Attack");
                    _cooldown = 0;
                }
                _animator.SetBool("IsRun", false);
            }
            else
            {
                _animator.SetBool("IsRun", true);
                Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, 4.5f * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
            _cooldown += Time.deltaTime;
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        if (_cooldown >= _cooldownStart)
    //        {
    //            _animator.SetTrigger("Attack");
    //            _cooldown = 0;
    //        }
    //        else
    //        {
    //            _cooldown += Time.deltaTime;
    //        }
    //        Debug.Log(_cooldown);
    //    }
    //}

    public void Attack()
    {
        playerData.TakeDamage(enemyData.GetDamage());
    }


}
