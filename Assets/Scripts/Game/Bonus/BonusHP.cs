using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHP : MonoBehaviour, IBonus
{
    public void Use()
    {
        EventBus.AOnAddHP?.Invoke(0);
        ObjectsPool.Instance.ReturnObject(this);
    }
}
