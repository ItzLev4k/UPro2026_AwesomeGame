using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPursuitEnemy : EnemyAbstractMove
{
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;

    public override void Init(Rigidbody2D rb, Transform trasform, Transform target, float speed)
    {
        base.Init(rb, trasform, target, speed);
    }

    public override void Move()
    {
        base.Move();

        Vector3 targetPosition = _targetTransform.position;
        _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref velocity, smoothTime, _speed, Time.deltaTime);
    }
}


