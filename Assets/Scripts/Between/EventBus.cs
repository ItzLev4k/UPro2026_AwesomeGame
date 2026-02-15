using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static Action<PanelDescription> OnInfoCharacter;
    public static Action<InfoWeapon> OnAddWeapon;
    public static Action<GameObject> OnWeaponDes;

    public static Action<float> AOnSubHPCharacter;
    public static Func<byte, float> FOnGetHPCharacter;

    public static Action<float> AOnSpeedCharacter;
    public static Action<float> AOnAddTimeDurationWeapon;
    public static Action<float> AOnAddTimeSpeedWeapon;
    public static Action<float> AOnAddTimeCreateEnemies;

    public static Func<byte, Vector2> OnControll;
    public static Func<byte, Vector2> OnPositionCharacter;

    public static Func<byte, float> FOnSpeedCharacter;
    public static Func<byte, float> FOnAddTimeDurationWeapon;
    public static Func<byte, float> FOnAddTimeSpeedWeapon;
    public static Func<byte, float> FOnAddTimeCreateEnemies;
}
