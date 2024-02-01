using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData 
{
    private static PlayerData instance;

    private float speed { get; set; }
    private float manaPoint { get; set; }
    private float healthPoint { get; set; }

    public static PlayerData getInstance()
    {
        if (instance == null)
            instance = new PlayerData();
        return instance;
    }

    public float GetSpeed() {  return speed; }
    public float GetManaPoint() { return manaPoint; }
    public float GetHealthPoint() { return healthPoint; }


}
