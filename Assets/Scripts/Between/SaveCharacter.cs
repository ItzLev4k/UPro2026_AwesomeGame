using UnityEngine;

public class SaveCharacter : Singleton<SaveCharacter>
{
    [SerializeField]
    InfoCharacter _currentCharacter;

    public  InfoCharacter CurrentCharacter { get => _currentCharacter; }

    public void Init()
    {
        EventBus.OnInfoCharacter += SetCurrentCharacter;
    }

    private void SetCurrentCharacter(PanelDescription panel)
    {
        _currentCharacter = panel.Info;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        EventBus.OnInfoCharacter -= SetCurrentCharacter;
    }
}
