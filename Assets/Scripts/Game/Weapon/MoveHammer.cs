using UnityEngine;
public class MoveHammer : AbstractStrategyMoveWeapon
{
    [Header("Timing Settings")]
    public float forwardDuration = 0.8f;
    public float backwardDuration = 1.5f;
    public float moveSpeed = 3f;

    private bool _movingForward = true;
    private float _nextSwitchTime;
    private Vector2 _cachedDirection;
    private float _cachedAngle;

    public override void Init(Rigidbody2D rb)
    {
        base.Init(rb);

        _cachedDirection = EventBus.OnControll.Invoke(0).normalized;
        _cachedAngle = Vector2.SignedAngle(Vector2.up, _cachedDirection) - 45f;

        _rigidbody.rotation = _cachedAngle;

        _nextSwitchTime = Time.time + forwardDuration;
    }

    public override void MoveWeapon()
    {
        base.MoveWeapon();

        if (Time.time >= _nextSwitchTime)
            SwitchDirection();

        Vector2 currentDirection = _movingForward ? _cachedDirection : -_cachedDirection;

        float speed = moveSpeed * EventBus.FOnAddTimeSpeedWeapon.Invoke(0);
        _rigidbody.MovePosition(_rigidbody.position + currentDirection * speed * Time.fixedDeltaTime);
    }

    private void SwitchDirection()
    {
        _movingForward = !_movingForward;

        _nextSwitchTime = Time.time + (_movingForward ? forwardDuration : backwardDuration);

        _rigidbody.rotation = _movingForward ? _cachedAngle : _cachedAngle - 180f;
    }
}

