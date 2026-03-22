using System;
using System.Collections;
using UnityEngine;
using YG;

public class CharacterSettings : MonoBehaviour
{
    private float _speedCharacter = 1;
    private float _addTimeDurationWeapon = 0;
    private float _addTimeSpeedWeapon = 1;
    private float _addTimeCreateEnemies = 0;

    private float _hp;

    public void Init(float HP)
    {
        EventBus.FOnSpeedCharacter += GetSpeed;
        EventBus.FOnAddTimeDurationWeapon += GetTDW;
        EventBus.FOnAddTimeSpeedWeapon += GetTSW;
        EventBus.FOnAddTimeCreateEnemies += GetTCE;

        EventBus.AOnSpeedCharacter += AddSpeed;
        EventBus.AOnAddTimeDurationWeapon += AddTDW;
        EventBus.AOnAddTimeSpeedWeapon += AddTSW;
        EventBus.AOnAddTimeCreateEnemies += AddTCE;
        EventBus.AOnAddHP += AddHP;

        EventBus.AOnSubHPCharacter += SetHp;
        EventBus.FOnGetHPCharacter += GetHP;
        _hp = HP;

        YG2.onCloseInterAdv += LoadMenu;
    }

    private void AddTCE(float obj)
    {
        _addTimeCreateEnemies += 0.1f;
    }

    private void AddTSW(float obj)
    {
        _addTimeSpeedWeapon += 0.1f;
    }

    private float GetHP(byte arg)
    {
        return _hp;
    }

    private void SetHp(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            if (YG2.isTimerAdvCompleted)
                YG2.InterstitialAdvShow();
            else LoadMenu();
    }

    private void LoadMenu()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return Load.Instance.LoadScene(1);
    }
    

    private void AddTDW(float obj)
    {
        _addTimeDurationWeapon += 0.1f;
    }

    private void AddSpeed(float obj)
    {
        _speedCharacter += 0.1f;
    }

    private void AddHP(float obj)
    {
        _hp += 0.1f;
    }

    private float GetTCE(byte arg)
    {
        return _addTimeCreateEnemies;
    }

    private float GetTSW(byte arg)
    {
        return _addTimeSpeedWeapon;
    }

    private float GetTDW(byte arg)
    {
        return _addTimeDurationWeapon;
    }

    private float GetSpeed(byte arg)
    {
        return _speedCharacter;
    }

    private void OnDestroy()
    {

        EventBus.FOnSpeedCharacter -= GetSpeed;
        EventBus.FOnAddTimeDurationWeapon -= GetTDW;
        EventBus.FOnAddTimeSpeedWeapon -= GetTSW;
        EventBus.FOnAddTimeCreateEnemies -= GetTCE;

        EventBus.AOnSpeedCharacter -= AddSpeed;
        EventBus.AOnAddTimeDurationWeapon -= AddTDW;
        EventBus.AOnAddTimeSpeedWeapon -= AddTSW;
        EventBus.AOnAddTimeCreateEnemies -= AddTCE;

        EventBus.AOnSubHPCharacter -= SetHp;
        EventBus.FOnGetHPCharacter -= GetHP;
        YG2.onCloseInterAdv -= LoadMenu;
    }
}