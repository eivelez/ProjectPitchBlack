using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject slot4;
    
    // Start is called before the first frame update
    void Start()
    {
        HideProductsSprites();
    }

    public void HideProductsSprites(){
        dollarSign.SetActive(true);
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(false);
        slot4.SetActive(false);
    }

    public void ShowProductsSprites(Dictionary<string, HealingItem> productsDictionary){
        dollarSign.SetActive(false);

        //Slot 1
        if (productsDictionary["Slot 1"] != null){
            slot1.SetActive(true);
        }

        //Slot 2
        if (productsDictionary["Slot 2"] != null){
            slot2.SetActive(true);
        }

        //Slot 3
        if (productsDictionary["Slot 3"] != null){
            slot3.SetActive(true);
        }

        //Slot 4
        if (productsDictionary["Slot 4"] != null){
            slot4.SetActive(true);
        }
    }
}
