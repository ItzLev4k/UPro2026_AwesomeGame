using UnityEngine;

public class CharacterInit : MonoBehaviour
{
    private SpriteRenderer _sr;

    public void Init()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = SaveCharacter.Instance.CurrentCharacter.Character;

        GetComponent<CharacterMove>().Init();
        GetComponent<CharacterSettings>().Init(SaveCharacter.Instance.CurrentCharacter.MaxHP);
    }
}
