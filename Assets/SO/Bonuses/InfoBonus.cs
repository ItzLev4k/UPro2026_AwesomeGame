using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Info/Bonus")]

public class InfoBonus : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private BonusType _bonusType;

    public Sprite Sprite { get => _sprite;}
    public BonusType BonusType { get => _bonusType;}

}

public enum BonusType
{
    Speed,
    TDW,
    TSW,
    TCE
}