using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMiniGame : MonoBehaviour
{
    public GameObject MashMiniGame;
    public GameObject SequenceMiniGame;
    public GameObject ArrowMiniGame;

    public MashMinigameScript mashMinigameScript;
    public SequenceMiniGameScript sequenceMiniGameScript;
    public ArrowMiniGameScript arrowMiniGameScript;

    private GameObject[] listOfMiniGames = new GameObject[3];
    private GameObject selectedMiniGame;
    // Start is called before the first frame update
    void Start()
    {
        /*MashMiniGame.SetActive(false);
        SequenceMiniGame.SetActive(false);
        gameObject.SetActive(false);*/
    }

    void OnEnable(){
        Time.timeScale = 0;
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
        selectedMiniGame.SetActive(true);
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
}
