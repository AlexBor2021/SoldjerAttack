using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Health> _enemyOnSpot;
    [SerializeField] private FinishMenu _finishMenu;

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

        _finishMenu.SetEnemyKills();

        _enemyOnSpot.Remove(enemy);

        if (_enemyOnSpot.Count == 0)
        {
            OnSpawnDie?.Invoke(this);

            gameObject.SetActive(false);
        }
    }

  
}
