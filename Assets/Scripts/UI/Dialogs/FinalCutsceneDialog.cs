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
        
        StartCoroutine(DialogCoroutine("John manages to defeat the creature with a final blow to the head",7));
          
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
                StartCoroutine(DialogCoroutine("Wounded and tired John can finally rest and wait for rescue",7));
                dialogIndex++;

                break;

            case 1:
                textLable.text="";
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("After a while John hears the helicopter approaching and starts shouting to be saved",9));
                dialogIndex++;
                break;

            case 2:
                textLable.text="";
                //Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Helicopter blades can be heard getting closer and closer, causing the fog around the rooftop to dissipate",12));
                dialogIndex++;
                break;

            case 3:
                textLable.text="";
                //Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John, almost in tears, watches the helicopter approach only to lose all hope moments later as he is ignored by his rescuers",13));
                dialogIndex++;
                break;

            case 4:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John, not understanding why he is not being rescued, notices, when the fog has dissipated, that a couple of blocks away from where he is, there is another building taller than the phragma building",19));
                dialogIndex++;
                break;

            case 5:
                textLable.text="";
                //Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John realizes that the tallest building he was supposed to climb is not phragma",8));
                dialogIndex++;
                break;

            case 6:
                textLable.text="";
                Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("His last hope vanishes in front of him",4));
                dialogIndex++;
                break;

            case 7:
                textLable.text="";
                //Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John defeated lets the fog envelop and consume him",6));
                dialogIndex++;
                break;

            case 8:
                textLable.text="";
                Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("The End …?",3));
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
