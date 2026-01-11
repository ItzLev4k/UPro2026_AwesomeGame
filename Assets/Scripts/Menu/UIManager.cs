using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelMain;
    [SerializeField]
    private GameObject _panelSettings;
    [SerializeField]
    private GameObject _panelChoose;

    private void Start()
    {
        OpenMain();
    }

    public void OpenMain()
    {
        _panelMain.SetActive(true);
        _panelSettings.SetActive(false);
        _panelChoose.SetActive(false);
    }

    public void OpenSettings()
    {
        _panelMain.SetActive(false);
        _panelSettings.SetActive(true);
        _panelChoose.SetActive(false);
    }

    public void OpenChoose()
    {
        _panelMain.SetActive(false);
        _panelSettings.SetActive(false);
        _panelChoose.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
