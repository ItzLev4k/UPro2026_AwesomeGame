using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class AbstractText : MonoBehaviour
{
    protected TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
}
