using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    private bool shopIsOpen = false;

    private void Update() {
        if (shopIsOpen){

        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E)){
            dollarSign.SetActive(false);
            shopIsOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        dollarSign.SetActive(true);
        shopIsOpen = false;
    }
}
