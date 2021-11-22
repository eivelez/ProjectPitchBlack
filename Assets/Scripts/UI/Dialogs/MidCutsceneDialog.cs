using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MidCutsceneDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    public GameObject EKey;
    public GameObject Image1;
    public GameObject Image2;
    private int dialogIndex=0;
    private bool next=false;

    void Start()
    {
        
        StartCoroutine(DialogCoroutine("John sigue su ascensión del edifico cuando siente algo por la espalda. Una sensación de que alguien lo observa",12));
          
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
                StartCoroutine(DialogCoroutine("John se da vuelta creyendo poder ver a alguien detrás de el en las escaleras. Podria ser otro sobreviviente",11));
                dialogIndex++;
                break;
            case 1:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John se acerca lentamente hasta poder ver mejor la figura delante de él",8));
                dialogIndex++;
                break;
            case 2:
                textLable.text="";
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Para cuando John se percata que lo que tiene al frente no es humano, ya es muy tarde para él",10));
                dialogIndex++;
                break;
            case 3:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("La criatura se abalanza sobre John lo que resulta en ambos cayendo por las escaleras",8));
                dialogIndex++;
                break;
            case 4:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John se despierta tiempo después adolorido por la caída. La criatura se ha escapado",10));
                dialogIndex++;
                break;
            case 5:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John agradece estar vivo y continua con su ascensión",5));
                dialogIndex++;
                break;
            case 6:
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
