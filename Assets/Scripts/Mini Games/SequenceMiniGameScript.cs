using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SequenceMiniGameScript : MonoBehaviour
{
    private int mash=0;
    public GameObject Success;
    public GameObject Fail;
    public Inventory inventory;
    public Text keyText1;
    public Text keyText2;
    public Text keyText3;
    public Text keyText4;
    public Text keyText5;
    public Text countDownText;
    public Text numberOfSequence;
    private float currentTime= 5f;
    private bool stopper=true;
    private string[] possibleKey= {"w","a","s","d","e","f","q","a","r","d","t","y","z","x","c"};
    private string[] selectedKeys= new string[6];
    private Text[] keybuttons= new Text[5];

    void OnEnable(){

        keybuttons[0]=keyText1;
        keybuttons[1]=keyText2;
        keybuttons[2]=keyText3;
        keybuttons[3]=keyText4;
        keybuttons[4]=keyText5;
        //gameObject.SetActive(false);
        Success.SetActive(false);
        Fail.SetActive(false);
        for (int i = 0; i < 5; i++) 
        {
          selectedKeys[i]=possibleKey[Random.Range (0, possibleKey.Length)];
          keybuttons[i].text=selectedKeys[i].ToUpper();
        }
        selectedKeys[5]=possibleKey[Random.Range (0, possibleKey.Length)];

    }

    // Update is called once per frame
    public void SequenceUpdate()
    {
        if(gameObject.activeSelf){
            if(currentTime>0f && stopper){       
                currentTime -= 1* Time.unscaledDeltaTime;
                countDownText.text=currentTime.ToString("0");
            }

            if (Input.GetKeyDown(selectedKeys[mash]) && mash<5 && stopper) {
                mash+=1;
                numberOfSequence.text=mash+"/5";
            }

            if(mash==5 && currentTime>0 ){
                Success.SetActive(true);
                numberOfSequence.text="";
                stopper=false;
                StartCoroutine(waiterNReset());

            }else if(mash<5 && currentTime<0){
                Fail.SetActive(true);
                numberOfSequence.text="";
                stopper=false;
                StartCoroutine(waiterNReset());
            }

        }
    }

    void ResetVariables(){
        if(currentTime<0){
            inventory.TakeDamage(50);
            //inventory.hp-=50;
        }
        if(mash==5){
            inventory.TakeDamage(10);
            //inventory.hp-=10;
        }
        Debug.Log(inventory.hp);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=5f;
        mash=0;
        stopper=true;
        numberOfSequence.text="0/5";
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
