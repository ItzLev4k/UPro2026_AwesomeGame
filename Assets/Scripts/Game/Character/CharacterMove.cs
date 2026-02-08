using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Controls inputActions;

    private Vector2 _oldTargetMove = Vector2.up;

    public void Init()
    {
        inputActions = new Controls();
        inputActions.Enable();

        _rb = GetComponent<Rigidbody2D>();

        EventBus.OnControll += GetControll;
        EventBus.OnPositionCharacter += GetPositionCharacter;
    }

    private void FixedUpdate()
    {
        _rb.AddForce(inputActions.CharacterControls.Move.ReadValue<Vector2>() * 5);
    }

    private Vector2 GetPositionCharacter(byte b)
    {
        return transform.position;
    }

    private Vector2 GetControll(byte b)
    {
        if (inputActions.CharacterControls.Move.ReadValue<Vector2>() != Vector2.zero)
            _oldTargetMove = inputActions.CharacterControls.Move.ReadValue<Vector2>();

        return _oldTargetMove;
    }

    private void OnDestroy()
    {
        EventBus.OnControll -= GetControll;
        EventBus.OnPositionCharacter -= GetPositionCharacter;

    }
}
