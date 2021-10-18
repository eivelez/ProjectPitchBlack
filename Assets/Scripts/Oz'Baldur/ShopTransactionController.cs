using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTransactionController : MonoBehaviour
{
    [SerializeField] private ShopSpriteController shopSpriteController;
    [SerializeField] private SlotController slotController1;
    [SerializeField] private SlotController slotController2;
    [SerializeField] private SlotController slotController3;
    private GameObject player;
    [HideInInspector] public bool playerShoping = false;

    /*TODO: USAR DICCIONARIO DE KEY: SLOT Y VALUE: OBJETO CON PRECIO O ALGO ASI Y Q EL SLOT ACCEDA A ÉL.
    private int SLOT1PRICE = 10;
    private int SLOT2PRICE = 5;
    private int SLOT3PRICE = 15;*/

    private void Start(){
        shopSpriteController = GetComponent<ShopSpriteController>();
        slotController1.Setup(this);
        slotController2.Setup(this);
        slotController3.Setup(this);
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
