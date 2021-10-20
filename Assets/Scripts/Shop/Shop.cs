using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopSpriteController shopSpriteController;
    public ShopTransactionController shopTransactionController;
    public Inventory inventory;
    [SerializeField] private SlotController slotController1;
    [SerializeField] private SlotController slotController2;
    [SerializeField] private SlotController slotController3;
    [HideInInspector] public bool playerShoping = false;

    private void Start() {
        shopSpriteController = GetComponent<ShopSpriteController>();
        shopTransactionController.Setup(this);
        slotController1.Setup(this);
        slotController2.Setup(this);
        slotController3.Setup(this);
    }
}
