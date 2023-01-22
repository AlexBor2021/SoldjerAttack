using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class IdleState : State
{
    [SerializeField] private Soldier _movePoint;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private float _duraction = 8;

    public bool _isInAttack;
    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _move;

    private void Start()
    {
       _move = _movePoint.transform.DOMove(_movePoint.MovePoint.position, _duraction);
    }

    public override State RunCurrentState()
    {
        if (_isInAttack)
        {
            _move.Kill();
            _chaseState.ReachThePosition();
            return _chaseState;
        }
        else
        {
            return this;
        }
    }
}
