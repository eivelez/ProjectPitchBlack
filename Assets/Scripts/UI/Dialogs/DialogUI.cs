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
        
        StartCoroutine(DialogCoroutine("Pragma, EE. UU. - 1998. Un pueblo remoto pero desarrollado",7));
          
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
                StartCoroutine(DialogCoroutine("El principal vestigio de la ciudad es el edificio fragma. La farmacéutica más reconocida en el país",12));
                dialogIndex++;

                break;

            case 1:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("John Doe trabaja para fragma. Su dedicación al trabajo ha resultado en el siendo una persona muy sola y aislada",12));
                dialogIndex++;
                break;

            case 2:
                textLable.text="";
                Image3.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("La aparición de una extraña niebla ha desatado el caos dentro del pueblo",10));
                dialogIndex++;
                break;

            case 3:
                textLable.text="";
                Image4.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Criaturas aterradoras emergen de la niebla destruyendo y matando todo a su alrededor",10));
                dialogIndex++;
                break;

            case 4:
                textLable.text="";
                Image5.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John se refugia en su casa esperando que la tragedia pase en un par de días. Quizás la niebla se disipe sola",12));
                dialogIndex++;
                break;

            case 5:
                textLable.text="";
                Image6.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Después de casi una semana las provisiones de John se han agotado. La única posibilidad de sobrevivir es salir y aventurarse dentro de la niebla",15));
                dialogIndex++;
                break;

            case 6:
                textLable.text="";
                Image7.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John deambula por las silenciosas calles del pueblo hasta que se topa con un cadáver de lo que solía ser un soldado",12));
                dialogIndex++;
                break;

            case 7:
                textLable.text="";
                Image8.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Entre las pertenencias John solo logra recuperar una linterna y una radio la cual repite una y otra vez el mismo mensaje",14));
                dialogIndex++;
                break;

            case 8:
                textLable.text="";
                //Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Extracción de emergencia en la torre más alta del pueblo a media noche. Extracción de emergencia en la torre más alta del pueblo a media noche",17));
                dialogIndex++;
                break;

            case 9:
                textLable.text="";
                Image9.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Con lo poco que tiene, John se arma de valor y se dirige a la torre fragma a afrontar los horrores de la niebla y así escapar de lo que queda del pueblo",16));
                dialogIndex++;
                break;
            case 10:
                SceneManager.LoadScene("Level1");
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

    }


}
