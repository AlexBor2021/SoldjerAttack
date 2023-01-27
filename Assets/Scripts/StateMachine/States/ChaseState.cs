using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _durationForPosition = 3;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Enemy _currentEnemy;

    public bool _isInAttackRange = false;

    public override State RunCurrentState()
    {
        if (_isInAttackRange)
        {
            if (ComeToEnemy())
            {
                _attackState._currentAim = _currentEnemy;
                _currentEnemy = null;
                _animator.SetBool("Run", false);
                return _attackState;
            }
            else
                return this;
        }
        else
        {
            ReachThePosition();
            _animator.SetBool("Run", true);
            return this;
        }
    }
    private bool ComeToEnemy()
    {
        Debug.Log(_currentEnemy.transform.position);
        _soldier.transform.LookAt(_currentEnemy.transform.position, Vector3.up);
        _navMeshAgent.SetDestination(_currentEnemy.transform.position);

        if (Vector3.Distance(_soldier.transform.position, _currentEnemy.transform.position) < 5)
        {
            _navMeshAgent.isStopped = true;
            return true;
        }
        else
            return false;
    }

    private void ReachThePosition()
    {
        Debug.Log(_soldier.WarPoint.position);
        _soldier.transform.LookAt(_soldier.WarPoint.position, Vector3.up);
        _navMeshAgent.SetDestination(_soldier.WarPoint.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _currentEnemy = enemy;
            _isInAttackRange = true;
        }
    }
}
