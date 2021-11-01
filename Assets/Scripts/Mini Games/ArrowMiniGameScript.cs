using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMiniGameScript : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject ArrowMiniGame;
    public GameObject Success;
    public GameObject Fail;
    public Inventory inventory;
    public Text countDownText;
    private bool stopper=true;
    private float currentTime= 5f;
    public float pointerSpeed=1.5f;
    private float pointerPosition;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnEnable(){
        Success.SetActive(false);
        Fail.SetActive(false);
        pointerPosition=Pointer.transform.position.x-ArrowMiniGame.transform.position.x;
        Debug.Log("initial "+pointerPosition);
    }

    // Update is called once per frame
    public void ArrowUpdate()
    {
        //Timer Logic
        if(currentTime>0f && stopper){       
                currentTime -= 1* Time.unscaledDeltaTime;
                countDownText.text=currentTime.ToString("0");
        }

        //Key Logic
        if (Input.GetKeyDown("e") && stopper) {
            pointerSpeed=0;
            stopper=false;
            if(pointerPosition>-28 && pointerPosition<43){
                Success.SetActive(true);
            }else{
                Fail.SetActive(true);
            }
            //Damage Logic
            StartCoroutine(waiterNReset(pointerPosition));
        }

        //TimeoutLogic
        if(currentTime<0f && stopper){
            pointerSpeed=0;
            stopper=false;
            Fail.SetActive(true);
            //Player Recive full damage
            StartCoroutine(waiterNReset(-300.0f));
        }


        //MOVIMIENTO FLECHA
        if(pointerPosition>330 || pointerPosition<-320){
            pointerSpeed *= -1;
            
        }
        Pointer.transform.position = new Vector2(Pointer.transform.position.x+pointerSpeed, Pointer.transform.position.y);
        pointerPosition+=pointerSpeed;
        
    }

    void ResetVariables(float position){
        DamageCalc(position);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=5f;
        pointerSpeed=1.5f;
        stopper=true;
        gameObject.SetActive(false);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void DamageCalc(float position){
        if(position<-220 || position>240){
            //Red Zone
            Debug.Log("Red Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(50);
        }else if(position<-115 || position>133){
            //Yellow Zone
            Debug.Log("Yellow Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(40);
        }
        else if(position<-28 || position>43){
            //Brown Zone
            Debug.Log("Brown Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(30);
        }else{
            //Green Zone
            Debug.Log("Green Zone");
            //Success.SetActive(true);
            inventory.TakeDamage(10);
        }
    }



    IEnumerator waiterNReset(float position)
    {
        
        //Wait for 3 seconds
        yield return new WaitForSecondsRealtime(3);
        ResetVariables(position);
    }
}
