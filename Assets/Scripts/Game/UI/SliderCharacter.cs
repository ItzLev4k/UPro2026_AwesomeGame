using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCharacter : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = EventBus.FOnGetHPCharacter.Invoke(0);
        _slider.value= EventBus.FOnGetHPCharacter.Invoke(0);
    }

    private void Update()
    {
        _slider.value = EventBus.FOnGetHPCharacter.Invoke(0);
    }
}
