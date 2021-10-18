using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject iconEKey;
    [SerializeField] private GameObject shopIcon;
    private bool shopIsOpen = false;

    private void Update() {
        if (shopIsOpen){

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        iconEKey.SetActive(true);
        shopIcon.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
            dollarSign.SetActive(false);
            iconEKey.SetActive(false);
            shopIcon.SetActive(false);
            shopIsOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        dollarSign.SetActive(true);
        iconEKey.SetActive(false);
        shopIcon.SetActive(false);
        shopIsOpen = false;
    }
}
