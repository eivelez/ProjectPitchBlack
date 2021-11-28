using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemSlotController : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private Sprite emptySprite;

    public void SetKeyItemIcon(Sprite keyItemSprite)
    {
        slotImage.sprite = keyItemSprite;
    }

    public void RemoveKeyItemIcon()
    {
        slotImage.sprite = emptySprite;
    }
}
