using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag.Equals("Player")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
