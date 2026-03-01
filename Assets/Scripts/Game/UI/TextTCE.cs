using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTCE : AbstractText
{
    private void Update()
    {
        if (_text != null)
        {
            _text.text = $"Bonus TCE: {EventBus.FOnAddTimeCreateEnemies.Invoke(0)}";
        }
    }
}
