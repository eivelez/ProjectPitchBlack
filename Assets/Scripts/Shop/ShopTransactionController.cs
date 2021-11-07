using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    private Shop shop;
    private Inventory playerInventory;
    [SerializeField] private AudioClip shopSFX;

    public void Setup(Shop shop){
        this.shop = shop;
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        shop.productsDictionary = new Dictionary<string, HealingItem>(){
            {"Slot 1", new Band_aid()},
            {"Slot 2", new FirstAidKit()},
            {"Slot 3", new ExtraLife()},
            {"Slot 4", new BulletproofVest()}
        };
    }

    public void BuyItem(GameObject slot){
        //Obtain the item on the slot selected
        HealingItem healingItem = shop.productsDictionary[slot.name];

        //We check the amount of money (fingers) of the player
        if (playerInventory.Fingers >= healingItem.price)
        {
            healingItem.Use(playerInventory);
            shop.productsDictionary[slot.name] = null;
            slot.SetActive(false);
            playerInventory.Fingers -= healingItem.price;
            AudioSource.PlayClipAtPoint(shopSFX, transform.position);
        }
    }
}
