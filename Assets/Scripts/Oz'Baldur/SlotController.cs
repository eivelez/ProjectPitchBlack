using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private ShopTransactionController shopTransactionController;

    public void Setup(ShopTransactionController shopTransactionController)
    {
        this.shopTransactionController = shopTransactionController;
    }

    void OnMouseDown(){
        if (shopTransactionController.playerShoping){
            shopTransactionController.BuyItem(this.gameObject);
        }
    }   
}
