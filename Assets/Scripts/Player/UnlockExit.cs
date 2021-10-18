using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockExit : MonoBehaviour
{
    Inventory inventory;
    BoxCollider2D boxColliderDoor;

    public int TOTAL_NUMBER_OF_KEYS = 1;
    private bool unlockDoor = false;
    private bool colliderDoorOff = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>();
        boxColliderDoor = GameObject.FindGameObjectWithTag("LockDoor").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UnLockDoor();
    }

    private void UnLockDoor() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (unlockDoor && !colliderDoorOff) 
            {
                boxColliderDoor.enabled = !boxColliderDoor.enabled;
                colliderDoorOff = true;
                RemovePlayerKeys();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject door = collision.gameObject;

        if (door.tag.Equals("LockDoor"))
        {
            if (PlayerHasAllTheKeys())
            {
                unlockDoor = true;
            }
        }
    }

    private bool PlayerHasAllTheKeys() 
    {
        if (inventory.key == TOTAL_NUMBER_OF_KEYS)
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
        inventory.key = 0;
    }
}
