using System.Collections.Generic;
using UnityEngine;

public class CreatePanelDescription : MonoBehaviour
{
    [SerializeField]
    private PanelDescription _prefabPanel;
    [SerializeField]
    private Transform _parent;

    public void Create(List<InfoCharacter> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            PanelDescription obj = ObjectsPool.Instance.GetObject(_prefabPanel).GetComponent<PanelDescription>();

            obj.transform.parent = _parent;
            obj.Spawn(list[i]);

            if (i == 0) EventBus.OnInfoCharacter?.Invoke(obj);
        }
    }
}


