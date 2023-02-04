using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : State
{
    [SerializeField] private AttackStateEnenmy _attackState;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;

    private Soldier _currentEnemy;

    public bool _isInAttackRange = false;

    public override State RunCurrentState()
    {
        if (_isInAttackRange)
        {
            if (ComeToEnemy())
            {
                if (_currentEnemy != null)
                {
                    _animator.SetBool("Run", false);
                    _attackState.SetAimForAttack(_currentEnemy);
                    return _attackState;
                }
                else
                    return this;
            }
            else
                return this;
        }
        else
        {
            _animator.SetBool("Run", false);
            return this;
        }
    }

    public void OffAim()
    {
        _currentEnemy = null;
        _isInAttackRange = false;
    }

    private bool ComeToEnemy()
    {
        _enemy.transform.LookAt(_currentEnemy.transform.position, Vector3.up);
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _currentEnemy.transform.position, 0.05f);
        _animator.SetBool("Run", true);

        if (Vector3.Distance(_enemy.transform.position, _currentEnemy.transform.position) < 4)
            return true;
        else
            return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Soldier soldier))
        {
            _currentEnemy = soldier;
            _isInAttackRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Soldier soldier))
        {
            _currentEnemy = null;
            _isInAttackRange = false;
        }
    }
}
