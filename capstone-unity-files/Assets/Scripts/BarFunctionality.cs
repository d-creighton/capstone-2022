using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFunctionality : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxSliderValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }
}
