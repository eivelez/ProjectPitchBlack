using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    private Shop shop;
    private Dictionary<string, HealingItem> productsDictionary;
    private Inventory inventory;

    public void Setup(Shop shop){
        this.shop = shop;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        productsDictionary = new Dictionary<string, HealingItem>(){
            {"Slot 1", new FirstAidKit()},
            {"Slot 2", new Band_aid()},
            {"Slot 3", new ExtraLife()}
        };
    }

    public void BuyItem(GameObject slot){
        productsDictionary[slot.name].Use(inventory);
        productsDictionary[slot.name] = null;
        slot.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerSprite>().ShowShopSprites();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E)){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerSprite>().HideShopSprites();
            shop.shopSpriteController.ShowProductsSprites(productsDictionary);
            shop.playerShoping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        GameObject player = other.gameObject;
        player.GetComponent<PlayerSprite>().HideShopSprites();
        shop.shopSpriteController.HideProductsSprites();
        shop.playerShoping = false;
    }
}
