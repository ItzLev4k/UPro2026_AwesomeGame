using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTSW : MonoBehaviour, IBonus
{
    public void Use()
    {
        EventBus.AOnAddTimeSpeedWeapon?.Invoke(0);
        ObjectsPool.Instance.ReturnObject(this);
    }
}
