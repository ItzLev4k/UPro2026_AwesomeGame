using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Localize : MonoBehaviour
{
    [SerializeField]
    private string localizationKey;

    private TMP_Text text;
    public string LocalizationKey { set => localizationKey = value; get => localizationKey; }

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        UpdateLocale();
    }

    void OnEnable()
    {
        UpdateLocale();
    }
        
    public void UpdateLocale()
    {
        if(text != null)
            if(CSVReader.isKeyText(localizationKey)) 
                text.text = CSVReader.getText(localizationKey);
    }

}

