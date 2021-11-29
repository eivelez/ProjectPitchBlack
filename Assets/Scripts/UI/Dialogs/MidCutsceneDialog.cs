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
    public AudioSource audioSource;
    private int dialogIndex=0;
    private bool next=false;

    void Start()
    {
        
        StartCoroutine(DialogCoroutine("John continues his ascent of the building when he feels something on his back. A feeling that someone is watching him",12));
          
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
                StartCoroutine(DialogCoroutine("John turns around thinking he can see someone behind him on the stairs. It could be another survivor",11));
                dialogIndex++;
                break;
            case 1:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John slowly approaches trying to get a better look at the figure in front of him",9));
                dialogIndex++;
                break;
            case 2:
                textLable.text="";
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("By the time John realizes that what is in front of him is not human, it is too late for him",10));
                dialogIndex++;
                break;
            case 3:
                textLable.text="";
                audioSource.Play();
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("The creature lunges at John resulting in both of them falling down the stairs",9));
                dialogIndex++;
                break;
            case 4:
                textLable.text="";
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John wakes up some time later in pain from the fall. The creature has escaped",9));
                dialogIndex++;
                break;
            case 5:
                textLable.text="";
                //Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("John is thankful to be alive and continues his ascension",7));
                dialogIndex++;
                break;
            case 6:
                SceneManager.LoadScene("Level 3-4 Transition");
                break;
            }
        }

        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("Level 3-4 Transition");
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
