using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FingersCountController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fingersCountText;

    public void SetFingerCounter(int fingers){
        fingersCountText.text = fingers.ToString();
    }
}
