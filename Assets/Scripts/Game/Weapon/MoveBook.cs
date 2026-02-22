using UnityEngine;

public class MoveBook : AbstractStrategyMoveWeapon
{
    public Vector3 centerObject;
    public float radius = 2f;
    public float angularSpeed = 1f;

    private float angle = 0f;

    public override void Init(Rigidbody2D _rb)
    {
        base.Init(_rb);

        _rigidbody.rotation = 0;

        centerObject = EventBus.OnPositionCharacter.Invoke(0);
    }

    public override void MoveWeapon()
    {
        base.MoveWeapon();

        angle += angularSpeed * EventBus.FOnAddTimeSpeedWeapon.Invoke(0) * Time.deltaTime;

        float x = centerObject.x + Mathf.Cos(angle) * radius;
        float y = centerObject.y + Mathf.Sin(angle) * radius;

        _rigidbody.transform.position = new Vector2(x, y);
    }

}