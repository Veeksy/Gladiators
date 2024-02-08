using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData: MonoBehaviour 
{
    private float healthPoint { get; set; }
    private float speed { get; set; }
    private float damage { get; set; }
    private float rangeAttack { get; set; }


    public float GetHealthPoint() { return healthPoint; }
    public float GetSpeed() { return speed; }
    public float GetDamage() { return damage; }
    public float GetRangeAttack() { return rangeAttack; }

    public void SetHealthPoint(float healthPoint) { this.healthPoint = healthPoint; }
    public void SetDamage(float damage) {  this.damage = damage; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetRangeAttack(float rangeAttack) { this.rangeAttack = rangeAttack; }


}
