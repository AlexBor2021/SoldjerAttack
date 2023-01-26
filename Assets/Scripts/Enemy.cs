using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _token;
    public int Health => _health;
    public int Damage => _damage;

    public override event Action<Health> Die;

    public override void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die?.Invoke(this);
            Instantiate(_token,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
