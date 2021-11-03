using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndDeathUI : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject DeathCanvasUI;
    public GameObject ContinueTxt;
    public GameObject DeadTxt;
    public GameObject YesBtn;
    public GameObject NoBtn;
    public GameObject WinTxt;
    public GameObject Background;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNoClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Intro");
    }

    public void OnYesClick()
    {
        Time.timeScale = 1;
        DeathCanvasUI.SetActive(false);
        ContinueTxt.SetActive(false);
        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
        WinTxt.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Death()
    {
        Player.GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 0;
        GameUI.SetActive(false);
        DeathCanvasUI.SetActive(true);
        DeadTxt.SetActive(true);
        ContinueTxt.SetActive(false);
        //YesBtn.SetActive(false);
        //NoBtn.SetActive(false);
        //WinTxt.SetActive(false);
        StartCoroutine(WaitForIntro());

    }
    public void Continue()
    {
        Player.GetComponent<Collider2D>().enabled = false;
        GameUI.SetActive(false);
        DeathCanvasUI.SetActive(true);
        //DeadTxt.SetActive(false);
        //WinTxt.SetActive(false);
        ContinueTxt.SetActive(true);
        YesBtn.SetActive(true);
        NoBtn.SetActive(true);
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("Intro");
    }

    public void Win()
    {
        Player.GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 0;
        GameUI.SetActive(false);
        DeathCanvasUI.SetActive(true);
        WinTxt.SetActive(true);
        //ContinueTxt.SetActive(false);
        //DeadTxt.SetActive(false);
        YesBtn.SetActive(false);
        NoBtn.SetActive(false);
        StartCoroutine(WaitForIntro());
    }
}
