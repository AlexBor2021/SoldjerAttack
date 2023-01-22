using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class IdleState : State
{
    [SerializeField] private Soldier _movePoint;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private Animator _animator;

    public bool _isInChaseState;

    public override State RunCurrentState()
    {
        if (_isInChaseState)
        {
            return _chaseState;
        }
        else
        {
            _movePoint.transform.position = Vector3.MoveTowards(_movePoint.transform.position, _movePoint.MovePoint.position, 0.05f);
           
            if (_movePoint.transform.position == _movePoint.MovePoint.position)
            {
                _animator.SetBool("Run", false);
            }
            else
            {
                _animator.SetBool("Run", true);
                _movePoint.transform.LookAt(_movePoint.MovePoint.position, Vector3.up);
            }

            return this;
        }
    }
}
