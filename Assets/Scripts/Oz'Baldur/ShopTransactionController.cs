using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    [SerializeField] private ShopSpriteController shopSpriteController;
    private GameObject player;
    private bool playerShoping = false;

    private void Start(){
        shopSpriteController = GetComponent<ShopSpriteController>();
    }

    private void Update() {
        if (playerShoping){
            
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
            playerShoping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        player.GetComponent<PlayerSpriteController>().HideShopSprites();
        shopSpriteController.HideProductsSprites();
        playerShoping = false;
    }
}
