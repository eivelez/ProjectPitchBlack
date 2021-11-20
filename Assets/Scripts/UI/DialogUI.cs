using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;
    public GameObject Image1;
    public GameObject Image2;
    private int dialogIndex=0;
    private bool next=false;

    void Start()
    {
        
        StartCoroutine(DialogCoroutine("Insert Text Here for unnecessary Lore Lore Lore Lore Lore Lore Lore",8));
          
    }

    void Update()
    {
        if(Input.GetKeyDown("e") && next)
        {
            switch (dialogIndex)
            {
            case 0:
                Image1.SetActive(false);
                //GetComponent<TextWritter>().Run("More Lore For Fuck Sake",textLable);
                StartCoroutine(DialogCoroutine("Insert Text Here for unnecessary Lore Lore Lore Lore Lore Lore Lore",8));
                dialogIndex++;
                break;
            case 1:
                Image2.SetActive(false);
                //GetComponent<TextWritter>().Run("PLZZZ Just Start the Game",textLable);
                StartCoroutine(DialogCoroutine("Insert Text Here for unnecessary Lore Lore Lore Lore Lore Lore Lore",8));
                dialogIndex++;
                break;
            }
        }
    }

    IEnumerator DialogCoroutine(string dialog,int time)
    {
        next=false;
        GetComponent<TextWritter>().Run(dialog,textLable); 
        yield return new WaitForSeconds(time);
        next=true;

    }


}
