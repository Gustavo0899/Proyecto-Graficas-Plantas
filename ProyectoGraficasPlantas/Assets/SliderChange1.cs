using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderChange1 : MonoBehaviour
{
    public Slider slider1;
    public TextMeshProUGUI sliderText1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderText1.text = slider1.value.ToString();
    }
}
