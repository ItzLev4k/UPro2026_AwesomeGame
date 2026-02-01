using UnityEngine;
using UnityEngine.UI;

public class SelectedPanelDescription : MonoBehaviour
{
    public void Init()
    {
        EventBus.OnInfoCharacter += SetImageAndText;
    }

    private void OnDestroy()
    {
        EventBus.OnInfoCharacter -= SetImageAndText;
    }

    private void SetImageAndText(PanelDescription description)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = description.Info.Character;
        transform.GetChild(1).GetComponent<Localize>().LocalizationKey = description.Info.Description;
        transform.GetChild(1).GetComponent<Localize>().UpdateLocale();
    }
}

