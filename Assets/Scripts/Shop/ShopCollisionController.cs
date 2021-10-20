using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCollisionController : MonoBehaviour
{
    private Shop shop;

    // Start is called before the first frame update
    public void Setup(Shop shop)
    {
        this.shop = shop;
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
            shop.shopSpriteController.ShowProductsSprites(shop.productsDictionary);
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
