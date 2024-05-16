using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livbar : MonoBehaviour
{
    public Slider slider;
    public float presentHealth;

    public void SetHalth(int presentHealth)
    {
        slider.value = presentHealth;
    }
}
