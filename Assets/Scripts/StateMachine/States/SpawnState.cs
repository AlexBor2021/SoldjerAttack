using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpawnState : State
{
    [SerializeField] private Soldier _movePoint;
    [SerializeField] private float _duraction = 5;
    [SerializeField] private IdleState _idleState;

    public override State RunCurrentState()
    {
        _movePoint.transform.DOMove(_movePoint.MovePoint.position, _duraction);
        return _idleState;
        
    }
   
}
