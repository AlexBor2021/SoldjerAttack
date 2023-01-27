using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IdleState : State
{
    [SerializeField] private Soldier _movePoint;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public bool _isInChaseState;

    public override State RunCurrentState()
    {
        if (_isInChaseState)
        {
            return _chaseState;
        }
        else
        {
            if (_movePoint.transform.position.x == _movePoint.MovePoint.position.x && _movePoint.transform.position.z == _movePoint.MovePoint.position.z)
            {
                _animator.SetBool("Run", false);
            }
            else
            {
                _navMeshAgent.SetDestination(_movePoint.MovePoint.position);
                _animator.SetBool("Run", true);
                _movePoint.transform.LookAt(_movePoint.MovePoint.position, Vector3.up);
            }

            return this;
        }
    }
}
