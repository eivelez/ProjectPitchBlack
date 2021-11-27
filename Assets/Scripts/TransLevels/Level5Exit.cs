using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag.Equals("Player")) 
        {
            player.GetComponent<Inventory>().SavePlayerStats();
            SceneManager.LoadScene("Level 5-6 Transition");
        }
    }
}
