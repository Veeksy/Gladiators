using UnityEngine;

public class PlayerData: MonoBehaviour
{
    private static PlayerData instance;

    private const float DEFAULT_SPEED = 5f;
    private int playerLevel { get; set; } = 1;

    private float speed { get; set; }
    private float manaPoint { get; set; } 
    private float healthPoint { get; set; } = 100;

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
    public void TakeDamage(int damage) 
    {
        healthPoint -= damage;
        Debug.Log(healthPoint);
    }

}
