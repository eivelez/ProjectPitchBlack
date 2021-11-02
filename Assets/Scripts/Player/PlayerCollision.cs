using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Inventory playerInventory;

    //Sound Effects
    [SerializeField] private AudioClip fingerSFX;
    [SerializeField] private AudioClip bulletproofVestSFX;
    [SerializeField] private AudioClip medikit_bandaid_SFX;
    [SerializeField] private AudioClip extraLifeSFX;

    public void Setup(Player player){
        playerInventory = player.inventory; 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finger"){
            PickUpFinger(other);
        }

        else if (other.tag == "BulletproofVest"){
            PickUpHealingItem(other.gameObject, new BulletproofVest(), bulletproofVestSFX);
        }
        
        else if (other.tag == "Band-aid"){
            PickUpHealingItem(other.gameObject, new Band_aid(), medikit_bandaid_SFX);
        }

        else if (other.tag == "FirstAidKit"){
            PickUpHealingItem(other.gameObject, new FirstAidKit(), medikit_bandaid_SFX);
        }

        else if (other.tag == "1UP"){
            PickUpHealingItem(other.gameObject, new ExtraLife(), extraLifeSFX);
        }

        else if (other.tag == "Key")
        {
            PickUpKey(other);
        }
    }

    private void PickUpFinger(Collider2D other){
        playerInventory.fingers += 1;
        AudioSource.PlayClipAtPoint(fingerSFX, transform.position);
        Destroy(other.gameObject);
    }

    private void PickUpHealingItem(GameObject itemGameObject, HealingItem healingItem, AudioClip soundEffect){
        healingItem.Use(playerInventory);
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Destroy(itemGameObject);
    }

    private void PickUpKey(Collider2D key)
    {
        playerInventory.keys += 1;
        //AudioSource.PlayClipAtPoint(fingerSFX, transform.position);
        Destroy(key.gameObject);
    }
}
