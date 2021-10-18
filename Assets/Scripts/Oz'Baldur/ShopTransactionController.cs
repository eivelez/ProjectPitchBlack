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
    private Dictionary<string, HealingItem> productsDictionary;

    private void Start(){
        shopSpriteController = GetComponent<ShopSpriteController>();
        productsDictionary = new Dictionary<string, HealingItem>(){
            {"Slot 1", new FirstAidKit()},
            {"Slot 2", new Band_aid()},
            {"Slot 3", new ExtraLife()}
        };
        slotController1.Setup(this);
        slotController2.Setup(this);
        slotController3.Setup(this);
    }

    public void BuyItem(GameObject slot){
        productsDictionary[slot.name].Use();
        productsDictionary[slot.name] = null;
        slot.SetActive(false);
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
            shopSpriteController.ShowProductsSprites(productsDictionary);
            playerShoping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        player.GetComponent<PlayerSpriteController>().HideShopSprites();
        shopSpriteController.HideProductsSprites();
        playerShoping = false;
    }
}
