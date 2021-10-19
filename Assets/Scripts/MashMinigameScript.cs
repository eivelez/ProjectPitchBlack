using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MashMinigameScript : MonoBehaviour
{
    //Utility variables
    private int mash=0;
    private int maxMash=50;
    public GameObject Success;
    public GameObject Fail;
    public Inventory inventory;
    public Text keyText;
    public Text countDownText;
    public Text numberOfMash;
    private float currentTime= 10f;
    private bool stopper=true;
    private string[] possibleKey= {"w","a","s","d","e","f","q","a","r","d","t","y","z","x","c"};
    private string selectedKey;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);

    }

    void OnEnable(){
        Success.SetActive(false);
        Fail.SetActive(false);
        selectedKey=possibleKey[Random.Range (0, possibleKey.Length)];
        keyText.text=selectedKey.ToUpper();
    }

    // Update is called once per frame
    public void MashUpdate()
    {
        if(gameObject.activeSelf){
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
        if(currentTime<0){
            inventory.hp-=50;
        }
        Debug.Log(inventory.hp);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=10f;
        mash=0;
        stopper=true;
        numberOfMash.text="0/"+maxMash;
        gameObject.SetActive(false);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    IEnumerator waiterNReset()
    {
    //Wait for 3 seconds
    yield return new WaitForSecondsRealtime(3);
    ResetVariables();
    }
}
