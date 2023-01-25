using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Health
{
    [SerializeField] public int _damage;
    [SerializeField] private int _health;

    public Transform MovePoint { get; private set; }
    public Transform WarPoint { get; private set; }
    public int Damage => _damage;
    public int Health => _health;

    public override event Action<Health> Die;

    public event Action<Soldier> Dead;

    public void SetStartPoint(Transform point, Transform warPoint)
    {
        MovePoint = point;
        WarPoint = warPoint;
    }
    
    public void ChangingBattlePoint(Transform warPoint)
    {
        WarPoint = warPoint;
    }

    public override void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dead?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
