using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
  [SerializeField] private ChaseState _chaseState;

    private bool _isCanSeeTarget;

    public override State RunCurrentState()
    {
        if (_isCanSeeTarget)
        {
            return _chaseState;
        }
        else
        {
            return this;
        }
    }
}
