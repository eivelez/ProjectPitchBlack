using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    private Shop shop;
    private Inventory inventory;

    public void Setup(Shop shop){
        this.shop = shop;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        shop.productsDictionary = new Dictionary<string, HealingItem>(){
            {"Slot 1", new FirstAidKit()},
            {"Slot 2", new Band_aid()},
            {"Slot 3", new ExtraLife()}
        };
    }

    public void BuyItem(GameObject slot){
        shop.productsDictionary[slot.name].Use(inventory);
        shop.productsDictionary[slot.name] = null;
        slot.SetActive(false);
    }
}
