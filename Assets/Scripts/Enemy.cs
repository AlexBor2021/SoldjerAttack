using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] private int _health;

    public int Health => _health;

    public override event Action<Health> Die;

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
