using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderControllerMusic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slidertext = null;
    [SerializeField] private float maxSliderAmount = 100.0f;

    public void vSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        slidertext.text = localValue.ToString("0");
    }
}
