using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _token;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private HitBullet _hitBullet;
    public int Health => _health;
    public int Damage => _damage;

    public override event Action<Health> Die;

    public override void TakeDamage(int damage)
    {
        _health -= damage;
        _hitBullet.SetHitBullet();

        if (_health <= 0)
        {
            Die?.Invoke(this);
            Instantiate(_token,transform.position,Quaternion.identity);
            Instantiate(_dieEffect, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
