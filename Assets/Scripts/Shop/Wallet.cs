using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet 
{
    private static int money { get; set; } = PlayerPrefs.GetInt("Wallet");

    public static int GetBalance() {  return money; }

    public static void Replenishment(int sum)
    {
        money += sum;
    }

    public static void WritingOf(int sum)
    {
        money -= sum;
    }

    public static void SetBalanse(int balance)
    {
        money = balance;
    }
}
