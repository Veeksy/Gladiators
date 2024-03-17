using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ShopItems 
{
    public string name { get; set; }
    public int price { get; set; }
    public bool buyed { get; set; }
    public bool selected {  get; set; }

    public static List<ShopItems> instance;

    public static List<ShopItems> getInstance()
    {
        if (instance == null)
            instance = new List<ShopItems>();
        return instance;
    }

}
