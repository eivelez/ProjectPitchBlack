using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Inventory>().key += 1;
            Destroy(gameObject);
        }
    }
}
