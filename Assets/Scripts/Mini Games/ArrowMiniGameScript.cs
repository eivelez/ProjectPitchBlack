using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject LeftLimit;
    public GameObject RightLimit;
    public GameObject LeftLimitYellow;
    public GameObject RightLimitYellow;
    public GameObject LeftLimitBrown;
    public GameObject RightLimitBrown;
    public GameObject LeftLimitGreen;
    public GameObject RightLimitGreen;

    public Inventory inventory;
    public Text countDownText;
    private bool stopper=true;
    private bool hammer=false;
    private float currentTime=6f;
    private float pointerSpeed=2000f;
    private Animator transition;
    [SerializeField] private MasterMiniGame masterMiniGame;
    [SerializeField] public AudioClip HitSound;

    public void Setup(Animator transition)
    {
        this.transition = transition;
    }

    void OnEnable(){
        EnemyImage.GetComponent<Image>().sprite=masterMiniGame.EnemySprite.GetComponent<SpriteRenderer>().sprite;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Success.SetActive(false);
        Fail.SetActive(false);
        if(inventory.hammer){
            hammer=true;
        }
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
                if(Pointer.transform.position.x>LeftLimitGreen.transform.position.x && Pointer.transform.position.x<RightLimitGreen.transform.position.x+8){
                    if(hammer){
                        StartCoroutine(FinalHit());
                    }
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
                StartCoroutine(waiterNReset(1000000000f));
            }


            //MOVIMIENTO FLECHA
            if(Pointer.transform.position.x<LeftLimit.transform.position.x || Pointer.transform.position.x>RightLimit.transform.position.x+8){
                pointerSpeed *= -1; 
            }
            Pointer.transform.position= new Vector3(Pointer.transform.position.x+(pointerSpeed*Time.unscaledDeltaTime),Screen.height/13,0);
            //Debug.Log("Pointer x loc "+(Pointer.transform.position.x));
            //pointerPosition+=pointerSpeed;
        }
    }

    void ResetVariables(float position){
        DamageCalc(position);
        Fail.SetActive(false);
        Success.SetActive(false);
        currentTime=6f;
        pointerSpeed=2000f;
        //gameObject.SetActive(false);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //SceneManager.LoadScene(0);
    }

    void DamageCalc(float position){
        //Debug.Log(position);
        //Debug.Log(LeftLimitYellow.transform.position.x+" "+RightLimitYellow.transform.position.x);
        if(Pointer.transform.position.x>LeftLimitGreen.transform.position.x && Pointer.transform.position.x<RightLimitGreen.transform.position.x+8){
            //Red Zone
            Debug.Log("Green Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(10*(100-inventory.defense)/100);
        }else if(position>LeftLimitBrown.transform.position.x && position<RightLimitBrown.transform.position.x+8){
            //Yellow Zone
            Debug.Log("Brown Zone");
            //Fail.SetActive(true);
            inventory.TakeDamage(30*(100-inventory.defense)/100);
        }
        else if(position>LeftLimitYellow.transform.position.x && position<RightLimitYellow.transform.position.x+8){
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
        AudioSource.PlayClipAtPoint(masterMiniGame.ExitSound, transform.position);
        yield return new WaitForSecondsRealtime(1);
        ResetVariables(position);
        yield return new WaitForSecondsRealtime(1);
        masterMiniGame.EnemyFinishedAttacking();
        Time.timeScale = 1;
        stopper=true;
        gameObject.SetActive(false);
    }

    IEnumerator FinalHit()
    {
        AudioSource.PlayClipAtPoint(HitSound, inventory.transform.position);
        //Wait for 3 seconds
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene("FinalCutscene", LoadSceneMode.Single);
    }
}
