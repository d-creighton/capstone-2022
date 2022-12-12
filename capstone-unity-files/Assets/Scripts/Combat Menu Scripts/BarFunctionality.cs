using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFunctionality : MonoBehaviour
{
    public Slider slider;

    public Text label;

    public void SetMaxSliderValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }

    public void SetLabel(int currentValue, int maxValue, string name)
    {
        label.text = name + "   " + currentValue + "/" + maxValue;
    }

    /* public void SetHolder(GameObject gameObject)
    {

    } */
}
