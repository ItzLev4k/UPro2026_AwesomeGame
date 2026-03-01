using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTCE : MonoBehaviour, IBonus
{
    public void Use()
    {
        EventBus.AOnAddTimeCreateEnemies?.Invoke(0);
        ObjectsPool.Instance.ReturnObject(this);
    }
}
