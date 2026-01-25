using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;

public class MyCustomLocalize : EditorWindow
{
    List<string> lines = new List<string>();

    Dictionary<string, List<string>> textLocal = new Dictionary<string, List<string>>();

    private Vector2 scrollPosition;

    [MenuItem("Localize/Open Window")]
    public static void ShowWindow()
    {
        GetWindow(typeof(MyCustomLocalize), true, "Localize Window");

        CSVReader.LoadCSV();
    }

    private void OnGUI()
    {
        if (!CSVReader.CheckDataCSV())
        {
            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Файл локализации не найден!");

            if (GUILayout.Button("Создать"))
            {
                CreateCSVFile();
            }

            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Файл локализации найден", GUILayout.Width(180));

            if (GUILayout.Button("Добавить язык")) CreateColum();

            if (GUILayout.Button("Добавить ключ")) CreateKey();

            if (GUILayout.Button("Сохранить")) SaveText();

            EditorGUILayout.EndHorizontal();

            if (textLocal == null) CreateStartValue();
            if (textLocal.Count == 0) CreateStartValue();

            EditorGUILayout.BeginHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(
                scrollPosition,
                 alwaysShowHorizontal: true,
                 alwaysShowVertical: true
                );

            EditorGUILayout.BeginVertical();

            for (int i = 0; i < textLocal.Count; i++)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.Width(200));
                float height = 23;

                for (int z = 0; z < textLocal[i.ToString()].Count; z++)
                {
                    GUIStyle style = GUI.skin.textArea;

                    if(height < style.CalcHeight(new GUIContent(textLocal[i.ToString()][z]), position.width - 10))
                    height = style.CalcHeight(new GUIContent(textLocal[i.ToString()][z]), position.width - 10);
                }

                for(int j = 0; j < textLocal[i.ToString()].Count; j++)
                {
                    textLocal[i.ToString()][j] = EditorGUILayout.TextArea(textLocal[i.ToString()][j], GUILayout.Height(height), GUILayout.Width(240));
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndHorizontal();
        }
    }

    private void SaveText()
    {
        string folderPath = Application.dataPath + "/Resources/CSV/";
        string filePath = folderPath + "Localization" + ".csv";
        string csvText = "";

        for (int i = 0; i < textLocal.Count; i++)
        {
            string newText = i != (textLocal.Count - 1) ? string.Join(";", textLocal[i.ToString()]) + "*#" : string.Join(";", textLocal[i.ToString()]);

            csvText = string.Concat(csvText, newText);
        }

        File.WriteAllText(filePath, csvText);

        if (filePath.StartsWith(Application.dataPath))
        {
            string relativePath = "Assets" + filePath.Substring(Application.dataPath.Length);
            AssetDatabase.ImportAsset(relativePath);
        }

        CSVReader.LoadCSV();
        Close();
    }

    private void CreateColum()
    {

        for (int i = 0; i < textLocal.Count; i++)
        {
            textLocal[i.ToString()].Add(" ");
        }

        Repaint();
    }

    private void CreateKey()
    {
        List<string> texts = new List<string>();

        for (int i = 0; i < textLocal["0"].Count; i++) texts.Add(" "); 

        textLocal.Add(textLocal.Count.ToString(), texts);

        Repaint();
    }

    private void CreateStartValue()
    {
        lines = new List<string>(Regex.Split(CSVReader.GetCSV().text, CSVReader.LINE_SPLIT_RE));
 
        for (int i = 0; i < lines.Count; i++)
        {
            if (!lines[i].Equals(""))
            {
                lines[i] = lines[i].TrimStart(CSVReader.TRIM_CHAR).TrimEnd(CSVReader.TRIM_CHAR).Replace("*#", "");
                textLocal.Add(i.ToString(), new List<string>(Regex.Split(lines[i], CSVReader.SPLIT_RE)));
            }
        }

    }

    private void CreateCSVFile()
    {
        string folderPath = Application.dataPath + "/Resources/CSV/";
        string filePath = folderPath + "Localization" + ".csv";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string[] headers = { "Key", "Ru", "En" };

        string csvText = string.Join(";", headers) + "*#";

        File.WriteAllText(filePath, csvText);

        if (filePath.StartsWith(Application.dataPath))
        {
            string relativePath = "Assets" + filePath.Substring(Application.dataPath.Length);
            AssetDatabase.ImportAsset(relativePath);
        }

        CSVReader.LoadCSV();
        CreateStartValue();
        Repaint();
    }
    private void OnEnable()
    {
        Repaint();
    }

    void OnDestroy()
    {
        lines.Clear();
        textLocal.Clear();
        Debug.Log("Окно закрыто, переменная очищена!");
    }
}
