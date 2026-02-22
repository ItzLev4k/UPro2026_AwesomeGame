using UnityEngine;

public class MoveSword : AbstractStrategyMoveWeapon
{
    public override void Init(Rigidbody2D _rb)
    {
        base.Init(_rb);

        _rigidbody.rotation = 0;

        _targetMoveCharacter = EventBus.OnControll.Invoke(0);


        float angle = Vector2.SignedAngle(Vector2.up, _targetMoveCharacter) - 45f;

        _rigidbody.rotation = angle;
    }

    public override void MoveWeapon()
    {
        base.MoveWeapon();

        _rigidbody.MovePosition(_rigidbody.transform.position + _targetMoveCharacter * EventBus.FOnAddTimeSpeedWeapon.Invoke(0) * 3 * Time.fixedDeltaTime);
    }

}