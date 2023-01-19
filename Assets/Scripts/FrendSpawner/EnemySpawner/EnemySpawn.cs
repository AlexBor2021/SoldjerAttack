using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Health> _enemyOnSpot;

    public event Action<EnemySpawn> OnSpawnDie;

    private void OnEnable()
    {
        foreach (var enemy in _enemyOnSpot)
        {
            enemy.Die += EnemyDie;
        }
    }

    private void EnemyDie(Health enemy)
    {
        enemy.Die -= EnemyDie;

        _enemyOnSpot.Remove(enemy);

        if (_enemyOnSpot.Count == 0)
        {
            OnSpawnDie?.Invoke(this);

            gameObject.SetActive(false);
        }
    }

  
}
