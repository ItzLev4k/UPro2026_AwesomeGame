using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllWaves : MonoBehaviour
{
    [SerializeField]
    private Enemy _prefabEnemy;
    [SerializeField]
    private List<Wave> _waves;

    [SerializeField]
    private byte _currentWave = 0;

    public void StartWaves()
    {
        StartCoroutine(Wave());
        StartCoroutine(NextWave());
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(_waves[_currentWave].Duration);

        _currentWave++;

        if (_currentWave == _waves.Count)
            StartCoroutine(LoadScene());
    }

    private IEnumerator Wave()
    {
        while (true)
        {
            GameObject enemy = ObjectsPool.Instance.GetObject<Enemy>(_prefabEnemy);

            int index = Random.Range(0, _waves[_currentWave].Enemies.Count);

            if (enemy != null)
                enemy.GetComponent<Enemy>().Init(_waves[_currentWave].Enemies[index]);

            yield return new WaitForSeconds(_waves[_currentWave].TimeBetweenSpawn + EventBus.FOnAddTimeCreateEnemies.Invoke(0));
        }
    }

    private IEnumerator LoadScene()
    {
        yield return Load.Instance.LoadScene(1);
    }
}


