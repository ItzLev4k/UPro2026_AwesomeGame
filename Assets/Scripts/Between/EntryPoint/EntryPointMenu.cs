using System.Collections.Generic;
using UnityEngine;

public class EntryPointMenu : MonoBehaviour
{
    [SerializeField]
    private PanelDescription _prefabPanel;

    [SerializeField]
    private List<InfoCharacter> _characterList;
    [SerializeField]
    private SetLanguageLocalization sll;
    [SerializeField]
    private CreatePanelDescription createPanelDescription;

    void Awake()
    {
        CSVReader.LoadCSV();
        sll.Init();

        ObjectsPool.Instance.AddObjects<PanelDescription>(_prefabPanel, 10);

        SaveCharacter.Instance.Init();

        FindObjectOfType<SelectedPanelDescription>().Init();

        createPanelDescription.Create(_characterList);
    }
}
