using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject firstAidKit;
    [SerializeField] private GameObject band_aid;
    [SerializeField] private GameObject oneup;
    
    // Start is called before the first frame update
    void Start()
    {
        dollarSign.SetActive(true);
        oneup.SetActive(false);
        firstAidKit.SetActive(false);
        band_aid.SetActive(false);
    }

    public void ShowProductsSprites(){
        dollarSign.SetActive(false);
        oneup.SetActive(true);
        firstAidKit.SetActive(true);
        band_aid.SetActive(true);
    }

    public void HideProductsSprites(){
        dollarSign.SetActive(true);
        oneup.SetActive(false);
        firstAidKit.SetActive(false);
        band_aid.SetActive(false);
    }
}
