using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    Hide hide;
    GameObject hidingPlace;
    // Start is called before the first frame update
    void Start()
    {
        hide = GameObject.FindGameObjectWithTag("Player").GetComponent<Hide>();
        hidingPlace = GameObject.FindGameObjectWithTag("HidingPlace");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Player = collision.gameObject;

        if (Player.tag.Equals("Player"))
        {
            hide.iconEKey.SetActive(true);
            hide.iconHideEye.SetActive(true);
            hide.SetPositionHide(hidingPlace);
            hide.canHide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject Player = collision.gameObject;

        if (Player.tag.Equals("Player"))
        {
            hide.canHide = false;
            hide.iconEKey.SetActive(false);
            hide.iconHideEye.SetActive(false);
            hide.redArrow.SetActive(false);
        }
    }
}
