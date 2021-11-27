using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMiniGame : MonoBehaviour
{
    public GameObject MashMiniGame;
    public GameObject SequenceMiniGame;
    public GameObject ArrowMiniGame;

    [SerializeField] private AudioClip EnterSound;
    [SerializeField] public AudioClip ExitSound;

    public GameObject Enemy;
    public SpriteRenderer EnemySprite;

    //EnemySpriteIndex
    public SpriteRenderer ZombieSprite;
    public SpriteRenderer SkeletonSprite;
    public SpriteRenderer MummySprite;

    [SerializeField] private Animator transition;

    public MashMinigameScript mashMinigameScript;
    public SequenceMiniGameScript sequenceMiniGameScript;
    public ArrowMiniGameScript arrowMiniGameScript;

    private GameObject[] listOfMiniGames = new GameObject[3];
    private GameObject selectedMiniGame;

    // Start is called before the first frame update
    void Start()
    {
        mashMinigameScript.Setup(transition);
        sequenceMiniGameScript.Setup(transition);
        arrowMiniGameScript.Setup(transition);
    }

    void OnEnable(){
        Time.timeScale = 0;
        AudioSource.PlayClipAtPoint(EnterSound, transform.position);
        transition.SetTrigger("Start");
        mashMinigameScript= gameObject.GetComponent<MashMinigameScript>();
        sequenceMiniGameScript= gameObject.GetComponent<SequenceMiniGameScript>();
        arrowMiniGameScript= gameObject.GetComponent<ArrowMiniGameScript>();
        listOfMiniGames[0]=MashMiniGame;
        listOfMiniGames[1]=SequenceMiniGame;
        listOfMiniGames[2]=ArrowMiniGame;

        for (int i = 0; i < listOfMiniGames.Length; i++) 
        {
          listOfMiniGames[i].SetActive(false);
        }
        selectedMiniGame=listOfMiniGames[Random.Range (0, listOfMiniGames.Length)];
        StartCoroutine(waiter());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedMiniGame==MashMiniGame){
            mashMinigameScript.MashUpdate();
        }
        if(selectedMiniGame==SequenceMiniGame){
            sequenceMiniGameScript.SequenceUpdate();
        }
        if(selectedMiniGame==ArrowMiniGame){
            arrowMiniGameScript.ArrowUpdate();
        }
        
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);
        selectedMiniGame.SetActive(true);
    }

    public void setEnemy(string enemyTag,GameObject enemyPassed){
        Enemy=enemyPassed;
        switch(enemyTag){
            case "Zombie":
                EnemySprite=ZombieSprite;
                break;
            case "Skeleton":
                EnemySprite = SkeletonSprite;
                break;
            case "Mummy":
                EnemySprite = MummySprite;
                break;

        }
    }

    public void EnemyFinishedAttacking(){
        Enemy.GetComponent<Enemy>().JustAttacked = true;
    }

}
