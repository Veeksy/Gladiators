using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float healthPoint { get; set; }
    [SerializeField]
    private float speed { get; set; }
    [SerializeField]
    private float damage { get; set; }
    [SerializeField]
    private float rangeAttack { get; set; }

    public float GetHealthPoint() { return healthPoint; }
    public float GetSpeed() { return speed; }
    public float GetDamage() { return damage; }
    public float GetRangeAttack() { return rangeAttack; }

    public void SetHealthPoint(float healthPoint) { this.healthPoint = healthPoint; }
    public void SetDamage(float damage) {  this.damage = damage; }
    public void SetSpeed(float speed) { this.speed = speed; }


    public void TakeDamage(int damage)
    {
        if (healthPoint > 0)
        {
            _animator.SetTrigger("Hurt");
            healthPoint -= damage;
        }
        if (healthPoint <= 0)
        {
            _animator.SetTrigger("Dead");
        }
    }

    public void IsDie()
    {
        Destroy(gameObject);
    }


}
