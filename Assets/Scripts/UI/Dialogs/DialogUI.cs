using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    public GameObject EKey;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;
    public GameObject Image8;
    public GameObject Image9;
    private int dialogIndex=0;
    private bool next=false;

    void Start()
    {
        
        StartCoroutine(DialogCoroutine("Pragma, USA. - 1998. A remote but developed town",5));
          
    }

    void Update()
    {
        if(Input.GetKeyDown("e") && next)
        {
            switch (dialogIndex)
            {
            case 0:
                textLable.text="";
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("The main landmark of the city is the phragma building. The most recognized pharmaceutical company in the country",12));
                dialogIndex++;

                break;

            case 1:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John Doe works for phragma. His dedication to the job has resulted in him being a very lonely and isolated person",12));
                dialogIndex++;
                break;

            case 2:
                textLable.text="";
                Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("The appearance of a strange fog has unleashed chaos on the streets",8));
                dialogIndex++;
                break;

            case 3:
                textLable.text="";
                Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Terrifying creatures emerge from the fog destroying and killing everything around them",9));
                dialogIndex++;
                break;

            case 4:
                textLable.text="";
                Image5.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John takes refuge in his house hoping that the tragedy will pass in a couple of days. Maybe the fog will dissipate on its own",14));
                dialogIndex++;
                break;

            case 5:
                textLable.text="";
                Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("After almost a week John's supplies have run out. The only chance of survival is to get out and venture into the fog",12));
                dialogIndex++;
                break;

            case 6:
                textLable.text="";
                Image7.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John wanders through the quiet streets of the town until he stumbles upon a corpse of what used to be a soldier",12));
                dialogIndex++;
                break;

            case 7:
                textLable.text="";
                Image8.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Among the belongings John only manages to recover a flashlight and a radio which repeats the same message over and over again",13));
                dialogIndex++;
                break;

            case 8:
                textLable.text="";
                //Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("'Midnight emergency extraction at the highest tower in town'. 'Midnight emergency extraction at the highest tower in town'",12));
                dialogIndex++;
                break;

            case 9:
                textLable.text="";
                Image9.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("With what little he has, John plucks up his courage and heads to the phragma tower to face the horrors of the fog and escape from what is left of the town",16));
                dialogIndex++;
                break;
            case 10:
                SceneManager.LoadScene("Level1");
                break;
            }
        }

        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("Level1");
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

    }


}
