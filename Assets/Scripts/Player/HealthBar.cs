using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    PlayerData playerData;
    private void Start()
    {
        playerData = PlayerData.getInstance();
        SetMaxHealth(playerData.GetMaxHealthPoint());
    }

    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    private void Update()
    {
        SetHealth(playerData.GetHealthPoint());
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

}
