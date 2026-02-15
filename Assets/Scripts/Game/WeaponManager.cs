using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Weapon _prefabWeapon;

    List<GameObject> list = new List<GameObject>();

    private GameObject _character;

    public void Init(GameObject character)
    {
        _character = character;
        EventBus.OnAddWeapon += AddWeapon;
    }

    private void AddWeapon(InfoWeapon weapon)
    {
        StartCoroutine(CreateWeapon(weapon));
    }

    private IEnumerator CreateWeapon(InfoWeapon weapon)
    {
        while (true)
        {
            GameObject obj = ObjectsPool.Instance.GetObject<Weapon>(_prefabWeapon);

            obj.GetComponent<Weapon>().InfoWeapon = weapon;
            obj.GetComponent<Weapon>().Init();
            obj.transform.position = _character.transform.position;

            yield return new WaitForSeconds(weapon.SpawnSec);
        }
    }

    private void OnDestroy()
    {
        EventBus.OnAddWeapon -= AddWeapon;
    }
}
