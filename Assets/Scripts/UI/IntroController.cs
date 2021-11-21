using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject canvas;
    bool fastEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Defense", 0);
        StartCoroutine(ButtonAppear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ButtonAppear()
    {
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        for(int i = 0; i<100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            canvas.GetComponent<CanvasGroup>().alpha += 0.01f;
            if(fastEnter)
            {
                break;
            }
        }
    }

    public void PlayButtonClicked()
    {
        StartCoroutine(VanishButton());
    }

    public IEnumerator VanishButton()
    {
        fastEnter = true;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            canvas.GetComponent<CanvasGroup>().alpha -= 0.01f;
            if(canvas.GetComponent<CanvasGroup>().alpha<=0)
            {
                break;
            }
        }
        SceneManager.LoadScene("IntroCutscene");
    }
}
