using DG.Tweening;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private float _durationForPosition = 3;

    public bool _isInAttackRange = false;
    private Enemy _currentEnemy;
    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _currentWarPoint;
    public DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _comingInEnemy;


    public override State RunCurrentState()
    {
        if (_isInAttackRange)
        {
            ComeToEnemy();
            _attackState._currentAim = _currentEnemy;
            Debug.Log(_currentEnemy.name);
            _currentEnemy = null;
            return _attackState;
        }
        else
        {
            return this;
        }
    }
    public void ComeToEnemy()
    {
        _comingInEnemy = _soldier.transform.DOMove(_currentEnemy.transform.position, 5);
    }

    public void ReachThePosition()
    {
        _currentWarPoint = _soldier.transform.DOMove(_soldier.WarPoint.position, _durationForPosition);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _currentEnemy = enemy;
            _isInAttackRange = true;
            _currentWarPoint.Kill();
        }

    }
}
