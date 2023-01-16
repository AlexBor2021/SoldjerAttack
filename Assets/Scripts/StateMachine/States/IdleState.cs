using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
  [SerializeField] private ChaseState _chaseState;

    public bool _isInAttack;

    public override State RunCurrentState()
    {
        if (_isInAttack)
        {
            _chaseState.ReachThePosition();
            return _chaseState;
        }
        else
        {
            return this;
        }
    }
}
