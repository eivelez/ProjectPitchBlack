using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWritter : MonoBehaviour
{
    [SerializeField] private float typeSpeed=5f;
    [SerializeField] public AudioClip typeSound;
    private float prebTime=0f;

    public void Run(string textToType,TMP_Text textLable){
        StartCoroutine(TypeText(textToType,textLable));
    }

    private IEnumerator TypeText(string textToType,TMP_Text textLable){
        float t = 0;
        int charIndex= 0;
        while(charIndex<textToType.Length){
            t+= Time.deltaTime*typeSpeed;
            
            charIndex = Mathf.FloorToInt(t);
            charIndex =  Mathf.Clamp(charIndex,0,textToType.Length);

            if(prebTime<charIndex && textToType[charIndex-1]!=' '){
                AudioSource.PlayClipAtPoint(typeSound, new Vector3(0,0,-10));
            }

            prebTime=charIndex;
            textLable.text= textToType.Substring(0,charIndex);

            yield return null;
        }
        textLable.text=textToType;
    }
}
