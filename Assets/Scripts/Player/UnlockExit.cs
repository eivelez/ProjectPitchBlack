using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockExit : MonoBehaviour
{
    private Inventory inventory;

    //Icons
    [SerializeField] private  GameObject eKeyIcon;
    [SerializeField] private  GameObject keyIcon;
    [SerializeField] private  GameObject noKeyIcon;
    [SerializeField] private GameObject axeIcon;
    [SerializeField] private GameObject noAxeIcon;
    [SerializeField] private GameObject extintorIcon;
    [SerializeField] private  GameObject noExtintorIcon;

    //Audio Clips
    [SerializeField] private AudioClip doorResistant;
    [SerializeField] private AudioClip doorOpening;
    [SerializeField] private AudioClip doorCutting;
    [SerializeField] private AudioClip extintorSound;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        DisableAllIcons();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject door = collision.gameObject;

        if (door.tag.Equals("LockDoor"))
        {
            eKeyIcon.SetActive(true);

            if (PlayerHasKeys())
            {
                keyIcon.SetActive(true);
            }
            else 
            {
                noKeyIcon.SetActive(true);
            }
        }

        if (door.tag.Equals("WoodDoor"))
        {
            eKeyIcon.SetActive(true);

            if (PlayerHasKeys())
            {
                axeIcon.SetActive(true);
            }
            else 
            {
                noAxeIcon.SetActive(true);
            }
        }

        if (door.tag.Equals("Fire"))
        {
            eKeyIcon.SetActive(true);

            if (PlayerHasKeys())
            {
                extintorIcon.SetActive(true);
            }
            else 
            {
                noExtintorIcon.SetActive(true);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject door = collision.gameObject;

        if (door.tag.Equals("LockDoor"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (PlayerHasKeys())
                {
                    AudioSource.PlayClipAtPoint(doorOpening, transform.position);
                    door.GetComponent<Animator>().SetBool("Unlocked", true);
                    RemovePlayerKeys();
                }
                else
                {
                    AudioSource.PlayClipAtPoint(doorResistant, transform.position);
                }
            }
        }

        if (door.tag.Equals("WoodDoor"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (PlayerHasKeys())
                {
                    AudioSource.PlayClipAtPoint(doorCutting, transform.position);
                    door.SetActive(false);
                    RemovePlayerKeys();       
                }
                else
                {
                    AudioSource.PlayClipAtPoint(doorResistant, transform.position);
                }
            }
        }

        if (door.tag.Equals("Fire"))
        {
            if (Input.GetKeyDown(KeyCode.E) && PlayerHasKeys()) 
            {
                AudioSource.PlayClipAtPoint(extintorSound, transform.position);
                door.SetActive(false);
                RemovePlayerKeys();       
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject door = collision.gameObject;

        if (door.tag.Equals("LockDoor") || door.tag.Equals("WoodDoor") || door.tag.Equals("Fire"))
        {
            DisableAllIcons();
        }
    }

    private bool PlayerHasKeys() 
    {
        if (inventory.keys >= 1)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private void RemovePlayerKeys() 
    {
        inventory.keys = 0;
        inventory.RemoveKeyItemUI();
    }

    private void DisableAllIcons() 
    {
        eKeyIcon.SetActive(false);
        keyIcon.SetActive(false);
        noKeyIcon.SetActive(false);
        axeIcon.SetActive(false);
        noAxeIcon.SetActive(false);
        extintorIcon.SetActive(false);
        noExtintorIcon.SetActive(false);
    }
}
