using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //Player stats and inventory
    public int keys = 0;
    public int hp = 100;
    public bool hammer=false;
    private const int MAXIMUM_HP = 100;
    private const int MAXIMUM_DEFENSE = 50;
    public int defense = 0;
    public int lives;
    private int fingers;

    //UI Controllers
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private LivesCounterController livesCounter;
    [SerializeField] private FingersCountController fingersCounter;
    [SerializeField] private KeyItemSlotController keyItemSlot;

    public WinAndDeathUI DeathUIController;

    //Properties
    public int Fingers
    {
        get { return fingers; }
        set
        {
            fingers = value;
            fingersCounter.SetFingerCounter(value);
        }
    }

    void Start(){
        SetPlayerStats();
    }

    void Update(){
        if (hp<=0){
            Time.timeScale = 0;
            lives-=1;
            PlayerPrefs.SetInt("Lives", lives);
            hp=MAXIMUM_HP;
            PlayerPrefs.SetInt("HP", hp);
            healthBar.SetMaxHealth(hp);
            livesCounter.SetLivesCounter(lives);
            if (lives <= 0)
            {
                ResetPlayerStatsAfterGameOver();
                DeathUIController.Death();
            }
            else
            {
                DeathUIController.Continue();
            }
        }
    }

    private void SetPlayerStats(){
        SetPlayerLives();
        SetPlayerHp();
        SetPlayerDefense();
        SetPlayerFingers();
        Debug.Log("lives: "+lives + "   hp:" + hp + " defense:" + defense + " fingers:" + fingers);
    }

    private void SetPlayerLives(){
        if (!PlayerPrefs.HasKey("Lives"))
        {
            PlayerPrefs.SetInt("Lives", 3);
        }
        lives=PlayerPrefs.GetInt("Lives");
        livesCounter.SetLivesCounter(lives);
    }

    private void SetPlayerHp(){
        if (!PlayerPrefs.HasKey("HP"))
        {
            PlayerPrefs.SetInt("HP", MAXIMUM_HP);
        }
        hp = PlayerPrefs.GetInt("HP");
        healthBar.SetHealth(hp);
    }

    private void SetPlayerDefense(){
        if (!PlayerPrefs.HasKey("Defense"))
        {
            PlayerPrefs.SetInt("Defense", 0);
        }
        defense=PlayerPrefs.GetInt("Defense");
    }

    private void SetPlayerFingers(){
        if (!PlayerPrefs.HasKey("Fingers"))
        {
            PlayerPrefs.SetInt("Fingers", 0);
        }
        Fingers = PlayerPrefs.GetInt("Fingers");
    }

    private void ResetPlayerStatsAfterGameOver(){
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("HP", MAXIMUM_HP);
        PlayerPrefs.SetInt("Defense", 0);
        PlayerPrefs.SetInt("Fingers", 0);
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

    //To save the stats of the player before going to the next level
    public void SavePlayerStats(){
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("HP", hp);
        PlayerPrefs.SetInt("Defense", defense);
        PlayerPrefs.SetInt("Fingers", fingers);
    }

    public void SetKeyItemInUI(Sprite keyItemSprite)
    {
        keyItemSlot.SetKeyItemIcon(keyItemSprite);
    }

    public void RemoveKeyItemUI()
    {
        keyItemSlot.RemoveKeyItemIcon();
    }
}
