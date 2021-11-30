using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuxLevel6Exit : MonoBehaviour
{
    // OJO: este es solo un script auxiliar ya que el cambio de escena se deberia activar despues de derrotar el jefe final
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.tag.Equals("Player")) 
        {
            SceneManager.LoadScene("FinalCutscene", LoadSceneMode.Single);
        }
    }
}
