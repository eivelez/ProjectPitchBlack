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
    public GameObject EnemyImage;
    public Inventory inventory;
    public Text countDownText;
    private bool stopper=true;
    private float currentTime=6f;
    public float pointerSpeed=3000f;
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
    private Animator transition;

    public void Setup(Animator transition)
    {
        this.transition = transition;
    }

    void OnEnable(){
        EnemyImage.GetComponent<Image>().sprite=gameObject.GetComponent<MasterMiniGame>().Enemy;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Success.SetActive(false);
        Fail.SetActive(false);
        //Debug.Log("Poniter "+pointerPosition);

        //RED ZONE
        auxRedZone=(RectTransform)RedZone.transform;
        maxRedZone=1650;
        minRedZone=300;
        //Debug.Log("Red "+maxRedZone+" "+minRedZone);

        //YELLOW ZONE
        auxYellowZone=(RectTransform)YellowZone.transform;
        maxYellowZone=1450;
        minYellowZone=500;
        //Debug.Log("Yellow "+maxYellowZone+" "+minYellowZone);

        //BROWN ZONE
        auxBrownZone=(RectTransform)BrownZone.transform;
        maxBrownZone=1230;
        minBrownZone=715;
        //Debug.Log("Brown "+maxBrownZone+" "+minBrownZone);

        //GREEN ZONE
        auxGreenZone=(RectTransform)GreenZone.transform;
        maxGreenZone=1050;
        minGreenZone=900;
        //Debug.Log("Green "+maxGreenZone+" "+minGreenZone);
    }

    // Update is called once per frame
    public void ArrowUpdate()
    {
        if(gameObject.activeSelf && stopper){
            //Timer Logic
            if(currentTime>0f && stopper){       
                    currentTime -= 1* Time.unscaledDeltaTime;
                    countDownText.text=currentTime.ToString("0");
            }

            //Key Logic
            if (Input.GetKeyDown("e") && stopper) {
                pointerSpeed=0;
                stopper=false;
                if(Pointer.transform.position.x>minGreenZone && Pointer.transform.position.x<maxGreenZone){
                    Success.SetActive(true);
                }else{
                    Fail.SetActive(true);
                }
                //Damage Logic
                StartCoroutine(waiterNReset(Pointer.transform.position.x));
            }

            //TimeoutLogic
            if(currentTime<0f && stopper){
                pointerSpeed=0;
                stopper=false;
                Fail.SetActive(true);
                //Player Recive full damage
                StartCoroutine(waiterNReset(maxRedZone+10f));
            }


            //MOVIMIENTO FLECHA
            if(Pointer.transform.position.x>maxRedZone || Pointer.transform.position.x<minRedZone){
                pointerSpeed *= -1; 
            }
            Pointer.transform.position= new Vector3(Pointer.transform.position.x+(pointerSpeed*Time.unscaledDeltaTime),103,0);
            Debug.Log("Pointer x loc "+(Pointer.transform.position.x));
            //pointerPosition+=pointerSpeed;
        }
    }

    void ResetVariables(float position){
        DamageCalc(position);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=6f;
        pointerSpeed=3000f;
        //gameObject.SetActive(false);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //SceneManager.LoadScene(0);
    }

    void DamageCalc(float position){
        Debug.Log(position);
        Debug.Log(minYellowZone+" "+maxYellowZone);
        if(position>minGreenZone && position<maxGreenZone){
            //Red Zone
            Debug.Log("Green Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(10*(100-inventory.defense)/100);
        }else if(position>minBrownZone && position<maxBrownZone){
            //Yellow Zone
            Debug.Log("Brown Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(30*(100-inventory.defense)/100);
        }
        else if(position>minYellowZone && position<maxYellowZone){
            //Brown Zone
            Debug.Log("Yellow Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(40*(100-inventory.defense)/100);
        }else{
            //Green Zone
            Debug.Log("Red Zone");
            //Success.SetActive(true);
            inventory.TakeDamage(50*(100-inventory.defense)/100);
        }
    }



    IEnumerator waiterNReset(float position)
    {
        
        //Wait for 3 seconds
        yield return new WaitForSecondsRealtime(3);
        transition.SetTrigger("Start");
        AudioSource.PlayClipAtPoint(gameObject.GetComponent<MasterMiniGame>().ExitSound, transform.position);
        yield return new WaitForSecondsRealtime(1);
        ResetVariables(position);
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        stopper=true;
        gameObject.SetActive(false);
    }
}
