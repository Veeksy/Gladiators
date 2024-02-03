using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private float healthPoint { get; set; }
    private float speed { get; set; }
    private int damage { get; set; }
    private float rangeAttack { get; set; }

    public float GetHealthPoint() { return healthPoint; }
    public float GetSpeed() { return speed; }
    public int GetDamage() { return damage; }
    public float GetRangeAttack() { return rangeAttack; }

    public void SetHealthPoint(float healthPoint) { this.healthPoint = healthPoint; }
    public void SetDamage(int damage) {  this.damage = damage; }
    public void SetSpeed(int speed) { this.speed = speed; }


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
