using UnityEngine;

public abstract class AbstractStrategyMoveWeapon
{
    protected Vector3 _targetMoveCharacter;
    protected Rigidbody2D _rigidbody;

    public virtual void Init(Rigidbody2D _rb)
    {
        _rigidbody = _rb;
    }

    public virtual void MoveWeapon()
    {

    }
}
