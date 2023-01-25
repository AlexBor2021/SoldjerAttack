using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemySpawns : MonoBehaviour
{
    [SerializeField] private List<EnemySpawn> _allEnemySpawns;
    [SerializeField] private GameObject _panelFinish;
    [SerializeField] private SpotForSpawn _spotSoldier;
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
        }
        else
        {
            Debug.Log("текущий спавн" + _allEnemySpawns[0].name);
            return _allEnemySpawns[0].transform;

        }
        return null;
    }

    private void SpawnDie(EnemySpawn spawn)
    {
        Debug.Log("Спавн умер" + spawn.name);
        _allEnemySpawns.Remove(spawn);
        _spotSoldier.ChangingWarPointForBots(_allEnemySpawns[0].transform);

    }
}
