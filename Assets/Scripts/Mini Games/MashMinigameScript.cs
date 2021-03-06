using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MashMinigameScript : MonoBehaviour
{
    //Utility variables
    public GameObject EnemyImage;
    private int mash=0;
    private int maxMash=50;
    public GameObject Success;
    public GameObject Fail;
    public Inventory inventory;
    public Text keyText;
    public Text countDownText;
    public Text numberOfMash;
    private float currentTime= 11f;
    private bool stopper=true;
    private string[] possibleKey= {"w","a","s","d","e","f","q","a","r","d","t","y","z","x","c"};
    private string selectedKey;
    private Animator transition;
    [SerializeField] private MasterMiniGame masterMiniGame;

    public void Setup(Animator transition)
    {
        this.transition = transition;
    }

    void OnEnable(){
        EnemyImage.GetComponent<Image>().sprite=masterMiniGame.EnemySprite.GetComponent<SpriteRenderer>().sprite;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Success.SetActive(false);
        Fail.SetActive(false);
        selectedKey=possibleKey[Random.Range (0, possibleKey.Length)];
        keyText.text=selectedKey.ToUpper();
    }

    // Update is called once per frame
    public void MashUpdate()
    {
        if(gameObject.activeSelf && stopper){
            if(currentTime>0f && stopper){       
                currentTime -= 1* Time.unscaledDeltaTime;
                countDownText.text=currentTime.ToString("0");
            }

            //Input Logic
            if (Input.GetKeyDown(selectedKey) && mash<maxMash && stopper) {
                mash+=1;
                numberOfMash.text=mash+"/"+maxMash;
            }

            //Win - Loss
            if(mash>=maxMash && currentTime>0 ){
                Success.SetActive(true);
                numberOfMash.text="";
                stopper=false;
                StartCoroutine(waiterNReset());

            }else if(mash<maxMash && currentTime<0){
                Fail.SetActive(true);
                
                numberOfMash.text="";
                stopper=false;
                StartCoroutine(waiterNReset());
            }
        }
        
    }

    void ResetVariables(){
        //timeout
        if(currentTime<0){
            if(mash<25){
                Debug.Log(50*(100-inventory.defense)/100);
                inventory.TakeDamage(50*(100-inventory.defense)/100);
            }else {
                Debug.Log(25*inventory.defense/100);
                inventory.TakeDamage(25*(100-inventory.defense)/100);
            }
            
            //inventory.hp-=50;
        }
        //success
        if(mash==maxMash){
            inventory.TakeDamage(10*(100-inventory.defense)/100);
            //inventory.hp-=10;
        }
        Debug.Log(inventory.hp);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=11f;
        mash=0;
        stopper=true;
        numberOfMash.text="0/"+maxMash;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //gameObject.SetActive(false);
        //SceneManager.LoadScene(0);
        //Time.timeScale = 1;
    }

    IEnumerator waiterNReset()
    {
    //Wait for 3 seconds
        yield return new WaitForSecondsRealtime(3);
        transition.SetTrigger("Start");
        AudioSource.PlayClipAtPoint(masterMiniGame.ExitSound, transform.position);
        yield return new WaitForSecondsRealtime(1);
        ResetVariables();
        yield return new WaitForSecondsRealtime(1);
        masterMiniGame.EnemyFinishedAttacking();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
        
}
