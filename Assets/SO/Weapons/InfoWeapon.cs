using UnityEngine;

[CreateAssetMenu(fileName = "InfoWeapon", menuName = "Info/Weapon")]

public class InfoWeapon : ScriptableObject
{
    [SerializeField]
    private TypeWeapon _typeWeapon;
    [SerializeField]
    private Sprite _weapon;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _despawnSec;
    [SerializeField]
    private float _spawnSec;

    public TypeWeapon TypeWeapon { get => _typeWeapon;}
    public Sprite Weapon { get => _weapon;}
    public float Damage { get => _damage;}
    public float Speed { get => _speed;}
    public float DespawnSec { get => _despawnSec;}
    public float SpawnSec { get => _spawnSec;}
}
public enum TypeWeapon
{
   Sword,
   Book,
   Hammer,
}