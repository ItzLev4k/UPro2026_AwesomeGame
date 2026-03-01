using System.Collections.Generic;
using UnityEngine;

public class MarkerBonus : MonoBehaviour
{
    [SerializeField]
    private List<InfoBonus> _listBonusInfo;

    public void Spawn(Transform position)
    {
        InfoBonus info = _listBonusInfo[Random.Range(0, _listBonusInfo.Count)];

        GetComponent<SpriteRenderer>().sprite = info.Sprite;
        switch (info.BonusType)
        {
            case BonusType.Speed:
                gameObject.AddComponent<BonusSpeed>();
                break;
            case BonusType.TSW:
                gameObject.AddComponent<BonusSpeed>();
                break;
            case BonusType.TDW:
                gameObject.AddComponent<BonusSpeed>();
                break;
            case BonusType.TCE:
                gameObject.AddComponent<BonusSpeed>();
                break;
        }

        transform.position = position.position;
    }
}
