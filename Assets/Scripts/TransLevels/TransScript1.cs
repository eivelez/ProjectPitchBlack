using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransScript1 : MonoBehaviour
{
    public GameObject player;
    public GameObject Key;
    private bool mover=false;
    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public AudioSource audioSource;
    private bool next=false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovementCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(mover){
            player.transform.position= Vector3.MoveTowards(player.transform.position,new Vector3(-2.14f,-2.6f,0),2f*Time.deltaTime);
        }
        if(Input.GetKeyDown("e") && next){
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }

    }

    IEnumerator MovementCoroutine()
    {
        yield return new WaitForSeconds(2);
        mover=true;
        audioSource.Play();
        sprite1.SetActive(false);
        sprite2.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite2.SetActive(false);
        sprite3.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite3.SetActive(false);
        sprite2.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite2.SetActive(false);
        sprite3.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite3.SetActive(false);
        sprite2.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite2.SetActive(false);
        sprite3.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite3.SetActive(false);
        sprite2.SetActive(true);

        yield return new WaitForSeconds(0.8f);
        sprite2.SetActive(false);
        sprite1.SetActive(true);
        audioSource.Stop();
        yield return new WaitForSeconds(1);
        Key.SetActive(true);
        next=true;

    }
}
