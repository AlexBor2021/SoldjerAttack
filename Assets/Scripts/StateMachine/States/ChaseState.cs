using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChaseState : State
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private float _durationForPosition = 5;

    private bool _isInAttackRange = false;

    public override State RunCurrentState()
    {
        if (_isInAttackRange)
        {
            return _attackState;
        }
        else
        {
            return this;
        }
    }

    public void ReachThePosition()
    {
       _soldier.transform.DOMove(_soldier.WarPoint.position, _durationForPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            _isInAttackRange = true;
        }

    }
}
