using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //Player stats and inventory
    public int keys = 0;
    public int hp = 100;
    private const int MAXIMUM_HP = 100;
    private const int MAXIMUM_DEFENSE = 50;
    public int defense = 0;
    public int lives;
    public int fingers = 0;

    //Controllers
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private LivesCounterController livesCounter;

    public DeathUI DeathUIController;
    public bool OneStateEnter;

    void Start(){
        OneStateEnter = true;
        SetPlayerStats();
    }

    void Update(){
        if (lives <= 0 && OneStateEnter)
        {
            DeathUIController.Death();
        }
        else if (hp<=0 && OneStateEnter){
            Time.timeScale = 0;
            lives-=1;
            PlayerPrefs.SetInt("Lives", lives);
            hp=MAXIMUM_HP;
            healthBar.SetHealth(hp);
            livesCounter.SetLivesCounter(lives);
            DeathUIController.Continue();
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
        if (defense + addedDefense >= MAXIMUM_DEFENSE ){
            defense = MAXIMUM_DEFENSE;
        }
        else{
            defense += addedDefense;
        }
        PlayerPrefs.SetInt("Defense", defense);
    }
}
