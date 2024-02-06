using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField]
    Slider manaSlider;
    PlayerData playerData;
    private void Start()
    {
        playerData = PlayerData.getInstance();
        SetMaxMana(playerData.GetMaxManaPoint());
    }

    public void SetMaxMana(float mana)
    {
        manaSlider.maxValue = mana;
        manaSlider.value = mana;
    }

    private void Update()
    {
        SetMana(playerData.GetManaPoint());
    }

    public void SetMana(float mana)
    {
        manaSlider.value = mana;
    }
}
