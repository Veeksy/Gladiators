using UnityEngine;

public class PlayerData: MonoBehaviour
{
    private static PlayerData instance;

    private const float DEFAULT_SPEED = 5f;
    private int playerLevel { get; set; } = 1;
    private float speed { get; set; }
    private float bonus_speed { get; set; }
    private float manaPoint { get; set; } 
    private float healthPoint { get; set; }

    public static PlayerData getInstance()
    {
        if (instance == null)
            instance = new PlayerData();
        return instance;
    }

    public float GetSpeed() {  return speed + DEFAULT_SPEED; }
    public float GetManaPoint() { return manaPoint; }
    public float GetHealthPoint() { return healthPoint; }
    public int GetPlayerLevel() { return playerLevel; }
    public float GetDefautSpeed() { return DEFAULT_SPEED; }
    public float GetBonusSpeed() { return bonus_speed; }

    public void setSpeed(float speed) { this.speed = speed; }
    public void setBonusSpeed(float b_speed) { this.bonus_speed = b_speed; }
    public void setHealthPoint(float healthPoint) { this.healthPoint = healthPoint; }


    public void TakeDamage(int damage) 
    {
        healthPoint -= damage;
        Debug.Log(healthPoint);
    }

}
