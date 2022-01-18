using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deflection : MonoBehaviour
{
    public GameObject DummyArrow;
    public Slider slider;
    private float previousValue;

    void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        this.previousValue = this.slider.value;
    }

    void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.DummyArrow.transform.Rotate(Vector3.up * delta * 180);
        this.previousValue = value;
    }
}

