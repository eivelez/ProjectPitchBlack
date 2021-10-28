using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private Shop shop;

    public void Setup(Shop shop)
    {
        this.shop = shop;
    }

    void OnMouseDown(){
        if (shop.playerShoping){
            shop.shopTransactionController.BuyItem(this.gameObject);
        }
    }   
}
