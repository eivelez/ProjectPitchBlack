using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag.Equals("Player")) 
        {
            player.GetComponent<Inventory>().SavePlayerStats();
            SceneManager.LoadScene("Level 2-3 Transition", LoadSceneMode.Single);
        }
    }
}
