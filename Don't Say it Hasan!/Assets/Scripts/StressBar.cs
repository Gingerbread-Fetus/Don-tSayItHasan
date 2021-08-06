using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    Slider slider;
    private void Awake() 
    {
        slider = GetComponent<Slider>();
    }

    public void AddStress(float damage)
    {
        slider.value += damage;
    }
}
