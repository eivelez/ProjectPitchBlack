using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounterController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesCountText;

    public void SetLivesCounter(int lives){
        livesCountText.text = lives.ToString();
    }
}
