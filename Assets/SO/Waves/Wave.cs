using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "Info/Waves")]

public class Wave : ScriptableObject
{
    [SerializeField]
    private float _duration;
    [SerializeField]
    private float _timeBetweenSpawn;
    [SerializeField]
    private List<EnemySO> _enemies;

    public float Duration { get => _duration;}
    public float TimeBetweenSpawn { get => _timeBetweenSpawn;}
    public List<EnemySO> Enemies { get => _enemies;}
}
