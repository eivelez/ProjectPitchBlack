using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] private GameObject iconEKey;
    [SerializeField] private GameObject iconHideEye;
    [SerializeField] private GameObject redArrow;
    [SerializeField] private GameObject shopIcon;

    // Start is called before the first frame update
    void Start()
    {
        iconEKey.SetActive(false);
        iconHideEye.SetActive(false);
        redArrow.SetActive(false);
        shopIcon.SetActive(false);
    }

    public void ShowShopSprites(){
        iconEKey.SetActive(true);
        shopIcon.SetActive(true);
    }

    public void HideShopSprites(){
        iconEKey.SetActive(false);
        shopIcon.SetActive(false);
    }
}
