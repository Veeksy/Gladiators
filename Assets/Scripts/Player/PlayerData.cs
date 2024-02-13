using UnityEngine;

public class PlayerData
{
    private static PlayerData instance;

    private const float DEFAULT_SPEED = 5f;
    private int playerLevel { get; set; } = 1;
    private float speed { get; set; }
    private float bonus_speed { get; set; } = 1f;
    private float maxManaPoint { get; set; }
    private float manaPoint { get; set; } 
    private float maxHealthPoint { get; set; }
    private float healthPoint { get; set; }
    private float damage { get; set; }

    public static PlayerData getInstance()
    {
        if (instance == null)
            instance = new PlayerData();
        return instance;
    }

    public float GetSpeed() {  return speed + DEFAULT_SPEED; }
    public float GetMaxManaPoint() { return maxManaPoint; }
    public float GetManaPoint() { return manaPoint; }
    public float GetMaxHealthPoint() { return maxHealthPoint; }
    public float GetHealthPoint() { return healthPoint; }
    public int GetPlayerLevel() { return playerLevel; }
    public float GetDefautSpeed() { return DEFAULT_SPEED; }
    public float GetBonusSpeed() { return bonus_speed; }
    public float GetDamage() { return damage; }


    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetBonusSpeed(float b_speed) { this.bonus_speed = b_speed; }
    public void SetHealthPoint(float healthPoint) { this.healthPoint = healthPoint; }
    public void SetManaPoint(float manaPoint) { this.manaPoint = manaPoint; }
    public void SetMaxHealthPoint(float maxHealthPoint) { this.maxHealthPoint = maxHealthPoint; }
    public void SetDamage(float damage) { this.damage = damage; }
    public void SetMaxManaPoint(float maxManaPoint) { this.maxManaPoint = maxManaPoint; }

    public void TakeDamage(float damage) 
    {
        healthPoint -= damage;
    }

}
