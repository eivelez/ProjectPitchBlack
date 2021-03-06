using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Inventory playerInventory;

    [SerializeField] private GameObject masterMiniGames;

    //Sound Effects
    [SerializeField] private AudioClip fingerSFX;
    [SerializeField] private AudioClip bulletproofVestSFX;
    [SerializeField] private AudioClip medikit_bandaid_SFX;
    [SerializeField] private AudioClip extraLifeSFX;
    [SerializeField] private AudioClip keySound;
    [SerializeField] private AudioClip hammersound;

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
        else if (other.tag == "Hammer"){
            PickUpHammer(other);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            masterMiniGames.GetComponent<MasterMiniGame>().setEnemy("Zombie",collision.gameObject);
            masterMiniGames.SetActive(true);
        }
        else if (collision.gameObject.tag == "Skeleton")
        {
            masterMiniGames.GetComponent<MasterMiniGame>().setEnemy("Skeleton", collision.gameObject);
            masterMiniGames.SetActive(true);
        }
        else if (collision.gameObject.tag == "Mummy")
        {
            masterMiniGames.GetComponent<MasterMiniGame>().setEnemy("Mummy", collision.gameObject);
            masterMiniGames.SetActive(true);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            masterMiniGames.GetComponent<MasterMiniGame>().setEnemy("Boss", collision.gameObject);
            masterMiniGames.SetActive(true);
        }
    }

    private void PickUpFinger(Collider2D other){
        playerInventory.Fingers += 1;
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
        playerInventory.SetKeyItemInUI(key.gameObject.GetComponent<SpriteRenderer>().sprite);
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        Destroy(key.gameObject);
    }

    private void PickUpHammer(Collider2D hammer)
    {
        playerInventory.hammer =true;
        playerInventory.SetKeyItemInUI(hammer.gameObject.GetComponent<SpriteRenderer>().sprite);
        AudioSource.PlayClipAtPoint(hammersound, transform.position);
        Destroy(hammer.gameObject);
    }
}
