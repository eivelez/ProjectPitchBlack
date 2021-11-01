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
    public GameObject RedZone;
    public GameObject YellowZone;
    public GameObject BrownZone;
    public GameObject GreenZone;
    public Inventory inventory;
    public Text countDownText;
    private bool stopper=true;
    private float currentTime= 100f;
    public float pointerSpeed=0.5f;
    private float pointerPosition;
    private float maxRedZone;
    private float minRedZone;
    private RectTransform auxRedZone;
    private float maxYellowZone;
    private float minYellowZone;
    private RectTransform auxYellowZone;
    private float maxBrownZone;
    private float minBrownZone;
    private RectTransform auxBrownZone;
    private float maxGreenZone;
    private float minGreenZone;
    private RectTransform auxGreenZone;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable(){
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Success.SetActive(false);
        Fail.SetActive(false);
        //Debug.Log("Poniter "+pointerPosition);

        //RED ZONE
        auxRedZone=(RectTransform)RedZone.transform;
        maxRedZone=(auxRedZone.rect.width/2)+5;
        minRedZone=(auxRedZone.rect.width/-2)+5;
        //Debug.Log("Red "+maxRedZone+" "+minRedZone);

        //YELLOW ZONE
        auxYellowZone=(RectTransform)YellowZone.transform;
        maxYellowZone=(auxYellowZone.rect.width/2)+5;
        minYellowZone=(auxYellowZone.rect.width/-2)+5;
        //Debug.Log("Yellow "+maxYellowZone+" "+minYellowZone);

        //BROWN ZONE
        auxBrownZone=(RectTransform)BrownZone.transform;
        maxBrownZone=(auxBrownZone.rect.width/2)+5;
        minBrownZone=(auxBrownZone.rect.width/-2)+5;
        //Debug.Log("Brown "+maxBrownZone+" "+minBrownZone);

        //GREEN ZONE
        auxGreenZone=(RectTransform)GreenZone.transform;
        maxGreenZone=(auxGreenZone.rect.width/2)+5;
        minGreenZone=(auxGreenZone.rect.width/-2)+5;
        //Debug.Log("Green "+maxGreenZone+" "+minGreenZone);
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
            if(pointerPosition<minBrownZone && pointerPosition>maxBrownZone){
                Success.SetActive(true);
            }else{
                Fail.SetActive(true);
            }
            //Damage Logic
            StartCoroutine(waiterNReset(pointerPosition));
        }

        //TimeoutLogic
        /*if(currentTime<0f && stopper){
            pointerSpeed=0;
            stopper=false;
            Fail.SetActive(true);
            //Player Recive full damage
            StartCoroutine(waiterNReset(maxRedZone+10f));
        }*/


        //MOVIMIENTO FLECHA
        /*if(pointerPosition>maxRedZone || pointerPosition<minRedZone){
            pointerSpeed *= -1;
            
        }*/
        Pointer.transform.position= new Vector3(Pointer.transform.position.x+(pointerSpeed*Time.unscaledDeltaTime),Pointer.transform.position.y,0);
        Debug.Log("Pointer x loc "+Pointer.transform.position.x);
        //pointerPosition+=pointerSpeed;
        
    }

    void ResetVariables(float position){
        DamageCalc(position);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=6f;
        pointerSpeed=1.5f;
        stopper=true;
        //gameObject.SetActive(false);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //SceneManager.LoadScene(0);
    }

    void DamageCalc(float position){
        Debug.Log(position);
        if(pointerPosition<minYellowZone || pointerPosition>maxYellowZone){
            //Red Zone
            Debug.Log("Red Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(50);
        }else if(pointerPosition<minBrownZone || pointerPosition>maxBrownZone){
            //Yellow Zone
            Debug.Log("Yellow Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(40);
        }
        else if(pointerPosition<minGreenZone || pointerPosition>maxGreenZone){
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
        transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        ResetVariables(position);
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
