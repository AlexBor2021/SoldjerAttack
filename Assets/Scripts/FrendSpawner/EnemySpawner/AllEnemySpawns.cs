using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemySpawns : MonoBehaviour
{
    [SerializeField] private List<EnemySpawn> _allEnemySpawns;
    [SerializeField] private GameObject _panelFinish;
    [SerializeField] private List<SpotForSpawn> _spotSoldier;


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
            _panelFinish.SetActive(true);
            Time.timeScale = 0;
            return null;
        }
        else
        {
            return _allEnemySpawns[0].transform;
        }
    }

    private void SpawnDie(EnemySpawn spawn)
    {
        _allEnemySpawns.Remove(spawn);

        if (_allEnemySpawns.Count != 0)
        {
            _spotSoldier[0].ChangingWarPointForBots(_allEnemySpawns[0].transform);
        }
        else
        {
            CurrentPointOfAttack();
        }
    }
}
