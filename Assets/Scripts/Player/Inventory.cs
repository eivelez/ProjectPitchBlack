using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //Player stats and inventory
    public int key = 0;
    public int hp = 100;
    private const int MAXIMUM_HP = 100;
    public int defense = 0;
    public int lives;
    public int fingers = 0;

    //Controllers
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private LivesCounterController livesCounter;

    void Start(){
        SetPlayerStats();
    }

    void Update(){
        if(hp<=0){
            lives-=1;
            PlayerPrefs.SetInt("Lives", lives);
            hp=MAXIMUM_HP;
            healthBar.SetHealth(hp);
            livesCounter.SetLivesCounter(lives);
            Debug.Log("Te moriste XDDDDDDDD y te quedan: "+lives+" vidas");
            if(lives==0){
                Debug.Log("Te real moriste XDDDD");
                ResetPlayerStatsAfterGameOver();
                Time.timeScale = 0;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void SetPlayerStats(){
        SetPlayerLives();
        SetPlayerMaxHp();
        SetPlayerDefense();
        Debug.Log("lives: "+lives + "   hp:" + hp);
    }

    private void SetPlayerLives(){
        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetInt("Lives", 3);
        }
        lives=PlayerPrefs.GetInt("Lives");
        livesCounter.SetLivesCounter(lives);
    }

    private void SetPlayerMaxHp(){
        hp = MAXIMUM_HP;
        healthBar.SetMaxHealth(hp);
    }

    private void SetPlayerDefense(){
        if (!PlayerPrefs.HasKey("Defense"))
        {
            PlayerPrefs.SetInt("Defense", 0);
        }
        defense=PlayerPrefs.GetInt("Defense");
    }

    private void ResetPlayerStatsAfterGameOver(){
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Defense", 0);
    }

    public void TakeDamage(int damageTaken){
        hp -= damageTaken;
        healthBar.SetHealth(hp);
    }

    public void Heal(int quantityOfHealthRestored){
        hp += quantityOfHealthRestored;
        if (hp > 100){
            hp = 100;
        }
        healthBar.SetHealth(hp);
    }

    public void AddExtraLife(){
        lives += 1;
        livesCounter.SetLivesCounter(lives);
    }

    public void IncreaseArmour(int addedDefense){
        defense += addedDefense;
        PlayerPrefs.SetInt("Defense", defense);
    }
}
