using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag.Equals("Player")) 
        {
            player.GetComponent<Inventory>().SavePlayerStats();
            SceneManager.LoadScene("MidCutscene", LoadSceneMode.Single);
        }
    }
}
