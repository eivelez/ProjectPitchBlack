using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject dollarSign;
    [SerializeField] private GameObject oneupIcon;
    [SerializeField] private GameObject firstAidKitIcon;
    [SerializeField] private GameObject band_aidIcon;
    // Start is called before the first frame update
    void Start()
    {
        dollarSign.SetActive(true);
        oneupIcon.SetActive(false);
        firstAidKitIcon.SetActive(false);
        band_aidIcon.SetActive(false);
    }

    public void ShowProductsSprites(){
        dollarSign.SetActive(false);
        oneupIcon.SetActive(true);
        firstAidKitIcon.SetActive(true);
        band_aidIcon.SetActive(true);
    }

    public void HideProductsSprites(){
        dollarSign.SetActive(true);
        oneupIcon.SetActive(false);
        firstAidKitIcon.SetActive(false);
        band_aidIcon.SetActive(false);
    }
}
