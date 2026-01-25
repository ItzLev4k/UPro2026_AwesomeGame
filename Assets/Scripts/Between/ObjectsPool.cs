using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : Singleton<ObjectsPool>
{
    private Dictionary<string, Stack<GameObject>> objects = new Dictionary<string, Stack<GameObject>>();

    public void AddObjects<T>(T prefab, int count) where T : MonoBehaviour
    {
        if (!objects.ContainsKey(prefab.GetType().ToString()))
            objects.Add(prefab.GetType().ToString(), new Stack<GameObject>());

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab).gameObject;
            obj.SetActive(false);
            objects[prefab.GetType().ToString()].Push(obj);
        }
    }

    public GameObject GetObject<T>(T prefab) where T : MonoBehaviour
    {
        if (objects.ContainsKey(prefab.GetType().ToString()))
        {
            Stack<GameObject> stack = objects[prefab.GetType().ToString()];

            if (stack.Count > 0)
            {
                GameObject obj = stack.Pop();
                obj.gameObject.SetActive(true);

                return obj;
            }
            else
            {
                GameObject newObj = Instantiate(prefab).gameObject;
                return newObj;
            }
        }
        else
        {
            GameObject newObj = Instantiate(prefab).gameObject;

            objects.Add(prefab.GetType().ToString(), new Stack<GameObject>(new[] { newObj }));

            return newObj;
        }
    }

    public void ReturnObject<T>(T obj) where T : MonoBehaviour
    {
        obj.gameObject.SetActive(false);

        if (!objects.ContainsKey(obj.GetType().ToString()))
            objects.Add(obj.GetType().ToString(), new Stack<GameObject>());

        objects[obj.GetType().ToString()].Push(obj.gameObject);

    }
}

