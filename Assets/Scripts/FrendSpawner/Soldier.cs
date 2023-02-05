using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Health
{
    [SerializeField] public int _damage;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _token;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private GameObject _panelDie;
    [SerializeField] private ParticleSystem _dieEffect;

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
            Instantiate(_dieEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            if (_isPlayer)
            {
                _panelDie.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Dead?.Invoke(this);
                Instantiate(_token, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}
