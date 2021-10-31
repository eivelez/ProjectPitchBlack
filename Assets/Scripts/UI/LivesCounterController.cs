using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounterController : MonoBehaviour
{
    [SerializeField] private Text livesCountText;

    public void SetLivesCounter(int lives){
        livesCountText.text = lives.ToString();
    }
}
