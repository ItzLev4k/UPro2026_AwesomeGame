using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVReader: Singleton<CSVReader>
{
    public static string SPLIT_RE = @";(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    public static string LINE_SPLIT_RE = @"\*\#";
    public static char[] TRIM_CHAR = {'$', '#'};

    static TextAsset dataCSV;
        
    static Dictionary<string, string> textAll = new Dictionary<string, string>();

    static string currentLanguage;

    public static string CurrentLanguage
    {
        get{return currentLanguage;}

        set
        {
            if(value != null && value.Trim() != string.Empty)
            {
                currentLanguage = value;

                textAll.Clear();

                string[] lines = Regex.Split(dataCSV.text, LINE_SPLIT_RE);

                int attributeIndex = -1;

                string[] headers = Regex.Split(lines[0], SPLIT_RE);

                for(int i = 0; i < headers.Length; i++)
                {
                    if(headers[i].Contains(currentLanguage))
                    {
                        attributeIndex = i;
                        break;
                    }
                }

                for(int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], SPLIT_RE);

                    for(int y = 0; y < values.Length; y++)
                    {
                        values[y] = values[y].TrimStart(TRIM_CHAR).TrimEnd(TRIM_CHAR).Replace("\\", "");
                    }

                    if(values.Length > attributeIndex)
                    {
                        string key = values[0];

                        if(textAll.ContainsKey(key)) continue;

                        string valueStr = values[attributeIndex];

                        textAll.Add(key, valueStr);
                    }
                }

                PlayerPrefs.GetString("Language", currentLanguage);
            }
        }
    }

    public static void LoadCSV()
    {
        dataCSV = Resources.Load("CSV/Localization") as TextAsset;
    }

    public static TextAsset GetCSV()
    {
        return dataCSV;
    }

    public static bool CheckDataCSV()
    {
        return dataCSV != null;
    }

    public static Dictionary<string, string> getTextAll()
    {
        return textAll;
    }

    public static string getText(string key)
    {
        return textAll[key];
    }

    public static bool isKeyText(string key)
    {
        return textAll.ContainsKey(key);
    }
}
