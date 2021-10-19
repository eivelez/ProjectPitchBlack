using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int key = 0;
    public int hp=100;
    public int lives;
    public HealthBarController healthBar;

    void Start(){
        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetInt("Lives", 3);
        }
        lives=PlayerPrefs.GetInt("Lives");
        Debug.Log("lives: "+lives);

        healthBar.SetMaxHealth(hp);
    }

    void Update(){
        if(hp<=0){
            lives-=1;
            PlayerPrefs.SetInt("Lives", lives);
            hp=100;
            healthBar.SetHealth(hp);
            Debug.Log("Te moriste XDDDDDDDD y te quedan: "+lives+" vidas");
            if(lives==0){
                Debug.Log("Te real moriste XDDDD");
                PlayerPrefs.SetInt("Lives", 3);
                Time.timeScale = 0;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(int damageTaken){
        hp -= damageTaken;
        healthBar.SetHealth(hp);
    }
}
