using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject iconEKey;
    [SerializeField] private GameObject shopIcon;
    [SerializeField] private GameObject oneupIcon;
    [SerializeField] private GameObject firstAidKitIcon;
    [SerializeField] private GameObject band_aidIcon;
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
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E)){
            dollarSign.SetActive(false);
            iconEKey.SetActive(false);
            shopIcon.SetActive(false);
            oneupIcon.SetActive(true);
            firstAidKitIcon.SetActive(true);
            band_aidIcon.SetActive(true);
            shopIsOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        dollarSign.SetActive(true);
        iconEKey.SetActive(false);
        shopIcon.SetActive(false);
        oneupIcon.SetActive(false);
        firstAidKitIcon.SetActive(false);
        band_aidIcon.SetActive(false);
        shopIsOpen = false;
    }
}
