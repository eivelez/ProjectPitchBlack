using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraCommandAndCheats : MonoBehaviour
{

    public Inventory inventory;

    void Update()
    {
        //Back to Menu
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Intro");
        }
        //Exit Game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Progession Cheats
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("1") || Input.GetKeyDown("1") && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level1");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("2") || Input.GetKeyDown("2") && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level2");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("3") || Input.GetKeyDown("3") && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level3");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("4") || Input.GetKeyDown("4") && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level4");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("5") || Input.GetKeyDown("5") && Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level5");
        }

        //CHEATS FOR ITEMS

        //Add 1 Finger
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("f") || Input.GetKeyDown("f") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.Fingers += 1;
        }
        //Full HP 
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("h") || Input.GetKeyDown("h") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.Heal(100);
        }
        //Add 1 key
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("k") || Input.GetKeyDown("k") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.keys += 1;
        }
        //Full Defense
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("d") || Input.GetKeyDown("d") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.defense = 50;
        }
        //No Defense
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("n") || Input.GetKeyDown("n") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.defense = 0;
        }
        //Add 1 Life
        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey("l") || Input.GetKeyDown("l") && Input.GetKey(KeyCode.LeftShift))
        {
            inventory.AddExtraLife();
        }



        
    }
}
