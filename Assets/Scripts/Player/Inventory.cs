using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int key = 0;
    public int hp = 100;
    private int maximumHp = 100;
    public int lives;
    public int fingers = 0;

    //Controllers
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private LivesCounterController livesCounter;

    //Sound Effects
    [SerializeField] private AudioClip fingerSFX;

    void Start(){
        SetPlayerStats();
    }

    void Update(){
        if(hp<=0){
            lives-=1;
            PlayerPrefs.SetInt("Lives", lives);
            hp=maximumHp;
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
        if (!PlayerPrefs.HasKey("MAXIMUM_HP"))
        {
            PlayerPrefs.SetInt("MAXIMUM_HP", 100);
        }
        maximumHp=PlayerPrefs.GetInt("MAXIMUM_HP");
        hp = maximumHp;
        healthBar.SetMaxHealth(hp);
        healthBar.SetHealth(hp);
    }

    private void ResetPlayerStatsAfterGameOver(){
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("MAXIMUM_HP", 100);
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

    public void ExtendHP(int extraHealth){
        maximumHp += extraHealth;
        PlayerPrefs.SetInt("MAXIMUM_HP", maximumHp);
        healthBar.SetMaxHealth(maximumHp);
    }

    private void PickUpFinger(Collider2D other){
        fingers += 1;
        AudioSource.PlayClipAtPoint(fingerSFX, transform.position);
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finger"){
            PickUpFinger(other);
        }
    }
}
