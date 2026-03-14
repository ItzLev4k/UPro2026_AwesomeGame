using UnityEngine;

public class MoveForward : EnemyAbstractMove
{
    private float _factorSpeed = 1.2f;
    private Vector3 _target;

    public override void Init(Rigidbody2D rb, Transform trasform, Transform target, float speed)
    {
        base.Init(rb, trasform, target, speed);

        _target = target.position - trasform.position;
    }

    public override void Move()
    {
        base.Move();

        _rb.MovePosition(_rb.transform.position + _target * _speed * _factorSpeed * Time.deltaTime);
    }
}