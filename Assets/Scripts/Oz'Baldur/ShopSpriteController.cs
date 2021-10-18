using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    
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
    }

    public void ShowProductsSprites(){
        dollarSign.SetActive(false);
        slot1.SetActive(true);
        slot2.SetActive(true);
        slot3.SetActive(true);
    }
}
