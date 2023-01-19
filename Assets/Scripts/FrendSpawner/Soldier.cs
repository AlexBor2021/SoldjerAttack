using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Health
{
    public Transform MovePoint { get; private set; }
    public Transform WarPoint { get; private set; }

    public override event Action<Health> Die;

    [SerializeField] private int _health;

    public void SetStartPoint(Transform point, Transform warPoint)
    {
        MovePoint = point;
        WarPoint = warPoint;
    }

    public override void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
