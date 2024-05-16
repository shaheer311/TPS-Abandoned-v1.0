using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slid : MonoBehaviour
{
    public Playerscript playerhealth;
    public Slider healthSlider;

    void Start()
    {
        // Initialize the slider's max value and current value
        healthSlider.maxValue = playerhealth.playerHealth;
        healthSlider.value = playerhealth.presentHealth;
    }

    void Update()
    {
        // Update the slider's value to match the player's current health
        healthSlider.value = playerhealth.presentHealth;
    }
}
