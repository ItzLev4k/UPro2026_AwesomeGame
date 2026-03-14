using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private MarkerBonus _bonusPrafabs;

    private float _speed;
    private float _damage;
    private float _HP;

    private bool isDamage = true;
    private EnemyAbstractMove _move;

    public void Init(EnemySO info)
    {
        _speed = info.Speed;
        _damage = info.Damage;
        _HP = info.MaxHP;

        GetComponent<SpriteRenderer>().sprite = info.SpriteEnemy;

        transform.position = GetRandomPositionOutsideCamera();

        gameObject.AddComponent<PolygonCollider2D>().isTrigger = true;

        int rand = Random.Range(0, 11);
        if (rand > 5) _move = new CharacterPursuitEnemy();
        else _move = new MoveForward();

        _move.Init(GetComponent<Rigidbody2D>(), transform,
            FindAnyObjectByType<CharacterMove>().transform, _speed);
    }

    private void Update()
    {
        if (_move != null) _move.Move();
    }

    private Vector2 GetRandomPositionOutsideCamera()
    {
        Camera mainCamera = Camera.main;
        Vector2 cameraCenter = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        int side = Random.Range(0, 4);

        Vector2 randomPosition = Vector2.zero;
        float padding = 1;

        switch (side)
        {
            case 0:
                randomPosition = new Vector2(
                    Random.Range(cameraCenter.x - cameraWidth / 2 - padding, cameraCenter.x + cameraWidth / 2 + padding),
                    cameraCenter.y + cameraHeight / 2 + padding);
                break;
            case 1:
                randomPosition = new Vector2(
                 cameraCenter.x + cameraWidth / 2 + padding,
                Random.Range(cameraCenter.y - cameraHeight / 2 - padding, cameraCenter.y + cameraHeight / 2 + padding));
                break;
            case 2:
                randomPosition = new Vector2(
                    Random.Range(cameraCenter.x - cameraWidth / 2 - padding, cameraCenter.x + cameraWidth / 2 + padding),
                    cameraCenter.y - cameraHeight / 2 - padding);
                break;
            case 3:
                randomPosition = new Vector2(
                 cameraCenter.x - cameraWidth / 2 - padding,
                Random.Range(cameraCenter.y - cameraHeight / 2 - padding, cameraCenter.y + cameraHeight / 2 + padding));
                break;
        }

        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Weapon>())
        {
            _HP -= collision.GetComponent<Weapon>().InfoWeapon.Damage;

            EventBus.OnWeaponDes?.Invoke(collision.gameObject);

            if(_HP <= 0)
            {
                GameObject obj = ObjectsPool.Instance.GetObject<MarkerBonus>(_bonusPrafabs);

                obj.GetComponent<MarkerBonus>().Spawn(transform);

                ObjectsPool.Instance.ReturnObject(this);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<CharacterMove>() && isDamage)
        {
            EventBus.AOnSubHPCharacter?.Invoke(_damage);
            isDamage = false;
            Invoke(nameof(ActiveDamage), 0.2f);
        }
    }

    private void ActiveDamage()
    {
        isDamage = true;
    }
}
