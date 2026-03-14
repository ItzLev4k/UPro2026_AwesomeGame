using UnityEngine;

public abstract class EnemyAbstractMove
{
    protected Rigidbody2D _rb;
    protected Transform _targetTransform;
    protected Transform _transform;
    protected float _speed;

    public virtual void Init(Rigidbody2D rb, Transform trasform, Transform target, float speed)
    {
        _rb = rb;
        _transform = trasform;
        _targetTransform = target;
        _speed = speed;
    }

    public virtual void Move()
    {

    }
}