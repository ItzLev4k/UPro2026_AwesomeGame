using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTSW : AbstractText
{
    private void Update()
    {
        if (_text != null)
        {
            _text.text = $"Bonus TSW: {EventBus.FOnAddTimeSpeedWeapon.Invoke(0)}";
        }
    }
}
