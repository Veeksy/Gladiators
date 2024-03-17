using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI countCoins;

    [SerializeField]
    List<ShopItems> _shopItems;

    [SerializeField]
    List<Button> buttonsItems;

    PlayerData playerData;

    void Awake()
    {
        if (YandexGame.SDKEnabled)
        {
            Wallet.SetBalanse(YandexGame.savesData.money);

            countCoins.text = Wallet.GetBalance().ToString();

            _shopItems = ShopItems.getInstance();
            _shopItems = YandexGame.savesData.shopItems;
        }
    }

    private void Start()
    {
        playerData = PlayerData.getInstance();
        if (_shopItems is null)
        {
            _shopItems = new List<ShopItems>();
            foreach (var item in buttonsItems)
            {
                _shopItems.Add(new ShopItems()
                {
                    name = item.name,
                    price = item.GetComponentInChildren<TextMeshProUGUI>().text != "�������" ? 
                    Convert.ToInt32(item.GetComponentInChildren<TextMeshProUGUI>().text) : 0,
                    buyed = item.GetComponentInChildren<TextMeshProUGUI>().text == "�������" ? true : false,
                    selected = false,
                });
            }

            if (_shopItems.Where(x => x.buyed == true).Count() < 2)
            {
                var defaultSelected = _shopItems.Where(x => x.buyed).FirstOrDefault();
                buttonsItems.Where(x => x.name == defaultSelected.name).FirstOrDefault()
                .GetComponentInChildren<TextMeshProUGUI>().text = "�������";
                defaultSelected.selected = true;
                playerData.SetSelectedPlayer(Convert.ToInt32(defaultSelected.name));
            }
        }
        else
        {
            foreach (var item in buttonsItems)
            {
                var _shopItem = _shopItems.Where(x => x.name == item.name).FirstOrDefault();

                Debug.Log($"��� {_shopItem.name}");
                Debug.Log($"������� {_shopItem.selected}");
                Debug.Log($"���� {_shopItem.price}");
                Debug.Log($"������� {_shopItem.buyed}");
                if (_shopItem.selected)
                    item.GetComponentInChildren<TextMeshProUGUI>().text = "�������";
                if (_shopItem.buyed && !_shopItem.selected)
                    item.GetComponentInChildren<TextMeshProUGUI>().text = "�������";
            }
        }
    }

    public void Buy(Button button)
    {
        var item = _shopItems.Where(x => x.name == button.name).FirstOrDefault();
        
        if (item != null) 
        {
            if (item.buyed == true)
            {
                _shopItems.ForEach(x=>x.selected = false);
                item.selected = true;
                buttonsItems.Where(x=>x.GetComponentInChildren<TextMeshProUGUI>().text == "�������").ToList()
                    .ForEach( x=> x.GetComponentInChildren<TextMeshProUGUI>().text = "�������");
                button.GetComponentInChildren<TextMeshProUGUI>().text = "�������";
            }
            else
            {
                if (Convert.ToInt32(button.GetComponentInChildren<TextMeshProUGUI>().text) <= Wallet.GetBalance())
                {
                    _shopItems.ForEach(x => x.selected = false);
                    item.selected = true;
                    item.buyed = true;

                    var listBuyed = _shopItems.Where(x=>x.buyed).ToList();

                    buttonsItems.Where(x => listBuyed.Select(x => x.name).Contains(x.name)).ToList()
                        .ForEach(x => x.GetComponentInChildren<TextMeshProUGUI>().text = "�������");

                    button.GetComponentInChildren<TextMeshProUGUI>().text = "�������";
                    playerData.SetSelectedPlayer(Convert.ToInt32(item.name));
                }
                else
                {

                }
            }
        }
        YandexGame.savesData.shopItems = _shopItems;
        YandexGame.SaveProgress();
    }
}
