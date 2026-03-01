using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTDW : MonoBehaviour, IBonus 
{
    public void Use()
    {
        EventBus.AOnAddTimeDurationWeapon?.Invoke(0);
        ObjectsPool.Instance.ReturnObject(this);
    }
}
