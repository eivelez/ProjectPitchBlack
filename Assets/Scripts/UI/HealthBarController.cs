using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    

    public void SetMaxHealth(int maxHealth){
        slider.maxValue = maxHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealth(int health){
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
