using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemySpawns : MonoBehaviour
{
    [SerializeField] private List<EnemySpawn> _allEnemySpawns;

    private void OnEnable()
    {
        foreach (var enemySpawn in _allEnemySpawns)
        {
            enemySpawn.OnSpawnDie += SpawnDie;
        }
    }

    public Transform CurrentPointOfAttack()
    {
        if (_allEnemySpawns.Count==0)
        {

        }
        else
        {
            return _allEnemySpawns[0].transform;

        }
        return null;
    }

    private void SpawnDie(EnemySpawn spawn)
    {
        _allEnemySpawns.Remove(spawn);
    }
}
