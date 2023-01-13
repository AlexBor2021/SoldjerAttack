using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState _attackState;

    private bool _isInAttackRange;

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
}
