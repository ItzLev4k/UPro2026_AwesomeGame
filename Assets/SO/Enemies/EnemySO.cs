using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Info/Enemy")]

public class EnemySO : ScriptableObject
{
    [SerializeField]
    private Sprite _spriteEnemy;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float maxHP;

    public Sprite SpriteEnemy { get => _spriteEnemy;}
    public float Damage { get => _damage;}
    public float Speed { get => _speed;}
    public float MaxHP { get => maxHP;}
}
