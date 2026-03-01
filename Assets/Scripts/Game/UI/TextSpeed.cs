using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpeed : AbstractText
{
    private void Update()
    {
        if(_text != null)
        {
            _text.text = $"Bonus Speed: {EventBus.FOnSpeedCharacter.Invoke(0)}";
        }
    }
}
