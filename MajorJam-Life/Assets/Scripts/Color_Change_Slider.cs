using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Change_Slider : MonoBehaviour
{
    public GameObject slider_fill;
    public Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider_fill.GetComponent<Image>().color = new Color(1 - slider.value / slider.maxValue, slider.value / slider.maxValue, slider_fill.GetComponent<Image>().color.b, .5f);
    }
}
