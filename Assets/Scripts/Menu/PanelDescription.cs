using UnityEngine;
using UnityEngine.UI;

public class PanelDescription : MonoBehaviour
{
    InfoCharacter _info;

    public InfoCharacter Info { get => _info; }

    private void OnDestroy()
    {
        EventBus.OnInfoCharacter -= SetBackground;
    }

    public void Spawn(InfoCharacter character)
    {
        _info = character;

        transform.GetChild(0).GetComponent<Image>().sprite = _info.Character;
        transform.GetChild(1).GetComponent<Localize>().LocalizationKey = _info.Description;
        transform.GetChild(2).GetComponent<Image>().sprite = _info.BaseWapon;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventBus.OnInfoCharacter?.Invoke(this);
        });

        GetComponent<RectTransform>().localScale = Vector3.one;
        GetComponent<RectTransform>().position = new Vector3(transform.position.x, transform.position.y, 0);
        EventBus.OnInfoCharacter += SetBackground;
    }

    private void SetBackground(PanelDescription panel)
    {
        if (panel == this)
            transform.GetComponent<Image>().color = new Color(0.1098039f, 0.2589324f, 0.3921569f, 1);
        else
            transform.GetComponent<Image>().color = new Color(0.4567818f, 0.6228967f, 0.8584906f, 1);
    }
}
