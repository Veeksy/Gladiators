using System.Collections;
using System.Collections.Generic;

public class Wallet 
{
    private static int money;

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
