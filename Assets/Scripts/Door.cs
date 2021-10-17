using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (inventory.key > 0 && Input.GetKey(KeyCode.E))
            {
                inventory.key -= 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
