using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private ShopSpriteController shopSpriteController;
    private bool shopIsOpen = false;

    private void Update() {
        if (shopIsOpen){
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            player = other.gameObject;
            player.GetComponent<PlayerSpriteController>().ShowShopSprites();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E)){
            player.GetComponent<PlayerSpriteController>().HideShopSprites();
            shopSpriteController.ShowProductsSprites();
            shopIsOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        player.GetComponent<PlayerSpriteController>().HideShopSprites();
        shopSpriteController.HideProductsSprites();
        shopIsOpen = false;
    }
}
