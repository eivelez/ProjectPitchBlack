using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalCutsceneDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    public GameObject EKey;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    private int dialogIndex=0;
    private bool next=false;

    void Start()
    {
        
        StartCoroutine(DialogCoroutine("John logra derrotar a la criatura con un ultimo golpe a la cabeza",8));
          
    }

    void Update()
    {
        if(Input.GetKeyDown("e") && next)
        {
            switch (dialogIndex)
            {
            case 0:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Herido y cansado John finalmente puede descansar y esperar por su rescate",8));
                dialogIndex++;

                break;

            case 1:
                textLable.text="";
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Después de un tiempo John escucha el helicóptero acercarse y empieza a gritar para que lo salven",9));
                dialogIndex++;
                break;

            case 2:
                textLable.text="";
                //Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Las aspas del helicóptero se escuchan cada vez más cerca y hacen que se disipe la niebla alrededor de la azotea",12));
                dialogIndex++;
                break;

            case 3:
                textLable.text="";
                //Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John, casi con lágrimas en los ojos, mira al helicóptero acercarse solo que para momentos después pierda toda la esperanza al ser ignorado por su rescate",19));
                dialogIndex++;
                break;

            case 4:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John sin entender porque no lo rescatan se percata, ya con la niebla semi disipada, que un par de cuadras más allá de donde está hay otro edificio más alto que el de fragma",19));
                dialogIndex++;
                break;

            case 5:
                textLable.text="";
                //Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John se da cuenta que el edificio más alto que debía subir no es fragma",9));
                dialogIndex++;
                break;

            case 6:
                textLable.text="";
                Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Su última esperanza se esfuma frente a él",5));
                dialogIndex++;
                break;

            case 7:
                textLable.text="";
                //Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John derrotado deja que la niebla lo envuelva y consuma",7));
                dialogIndex++;
                break;

            case 8:
                textLable.text="";
                Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Fin …?",3));
                dialogIndex++;
                break;
            case 9:
                SceneManager.LoadScene("Intro");
                break;
            }
        }
    }

    IEnumerator DialogCoroutine(string dialog,int time)
    {
        EKey.SetActive(false);
        next=false;
        GetComponent<TextWritter>().Run(dialog,textLable); 
        yield return new WaitForSeconds(time);
        next=true;
        EKey.SetActive(true);

    }}
