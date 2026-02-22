using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private InfoWeapon _infoWeapon;

    private SpriteRenderer _spriteRenderer;
    private AbstractStrategyMoveWeapon _strategyMoveWeapon;

    public InfoWeapon InfoWeapon { get => _infoWeapon; set => _infoWeapon = value; }

    public void Init()
    {
        Invoke(nameof(Despawn), _infoWeapon.DespawnSec + EventBus.FOnAddTimeDurationWeapon.Invoke(0));

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _infoWeapon.Weapon;

        Destroy(GetComponent<Collider2D>());

        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;

        switch (InfoWeapon.TypeWeapon)
        {
            case TypeWeapon.Sword:
                _strategyMoveWeapon = new MoveSword();
                break;
            case TypeWeapon.Book:
                _strategyMoveWeapon = new MoveBook();
                break;
            case TypeWeapon.Hammer:
                _strategyMoveWeapon = new MoveHammer();
                break;
            default:
                _strategyMoveWeapon = new MoveSword();
                break;
        }

        _strategyMoveWeapon.Init(GetComponent<Rigidbody2D>());

        EventBus.OnWeaponDes += CheckWeapon;
    }

    private void Update()
    {
        _strategyMoveWeapon.MoveWeapon();
    }

    private void CheckWeapon(GameObject obj)
    {
        if (obj == gameObject) Despawn();
    }

    private void Despawn()
    {
        ObjectsPool.Instance.ReturnObject(this);
        EventBus.OnWeaponDes -= CheckWeapon;
    }

    private void OnDestroy()
    {
        EventBus.OnWeaponDes -= CheckWeapon;
    }
}