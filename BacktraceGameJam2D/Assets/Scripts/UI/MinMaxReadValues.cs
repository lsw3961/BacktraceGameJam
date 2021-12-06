using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MinMaxReadValues : MonoBehaviour
{
    Slider slider;
    [SerializeField] TMP_Text minValue;
    [SerializeField]TMP_Text maxValue;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        if (minValue.text != slider.minValue.ToString())
        {
            minValue.text = slider.minValue.ToString();
        }
        if (maxValue.text != slider.maxValue.ToString())
        {
            maxValue.text = slider.maxValue.ToString();
        }
    }

}
