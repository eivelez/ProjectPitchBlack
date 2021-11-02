using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Inventory playerInventory;

    //[SerializeField] private GameObject masterMiniGames;

    //Sound Effects
    [SerializeField] private AudioClip fingerSFX;
    [SerializeField] private AudioClip bulletproofVestSFX;
    [SerializeField] private AudioClip medikit_bandaid_SFX;
    [SerializeField] private AudioClip extraLifeSFX;
    [SerializeField] private AudioClip keySound;

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

        else if (other.tag == "Key"){
            PickUpKey(other);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enter Enemy");
            masterMiniGames.GetComponent<MasterMiniGame>().setEnemy(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
            masterMiniGames.SetActive(true);
        }
    }*/

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
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(key.gameObject);
    }
}
