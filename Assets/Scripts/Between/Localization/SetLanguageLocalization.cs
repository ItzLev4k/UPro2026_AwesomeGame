using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLanguageLocalization : MonoBehaviour
{
    public void Init()
    {
        if(!PlayerPrefs.HasKey("LanguageSave"))
            switch(Application.systemLanguage)
            {
                case SystemLanguage.English:
                    setLanguage("En");
                    break;
                case SystemLanguage.Russian:
                    setLanguage("Ru");
                    break;
                default:
                    setLanguage("En");
                    break;
            }
        else
            setLanguage(PlayerPrefs.GetString("LanguageSave"));
    }
    
    public void setLanguage(string language)
    {
        CSVReader.CurrentLanguage = language;
        PlayerPrefs.SetString("LanguageSave", language);

        foreach(Localize loc in FindObjectsOfType<Localize>())
            loc.UpdateLocale();
    }
}
