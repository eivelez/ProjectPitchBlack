using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int key = 0;
    public int hp=100;
    public int lives=3;

     void Update(){
        if(hp<=0){
            lives-=1;
            hp=100;
            Debug.Log("Te moriste XDDDDDDDD y te quedan: "+lives+" vidas");
            if(lives==0){
                Debug.Log("Te real moriste XDDDD");
                Time.timeScale = 0;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
     }
}
