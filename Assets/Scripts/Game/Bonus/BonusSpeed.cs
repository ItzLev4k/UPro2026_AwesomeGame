using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeed : MonoBehaviour, IBonus
{
    public void Use()
    {
        EventBus.AOnSpeedCharacter?.Invoke(0);
        ObjectsPool.Instance.ReturnObject(this);
    }
}
