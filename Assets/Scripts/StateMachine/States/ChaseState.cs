using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChaseState : State
{
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private float _durationForPosition = 5;

    private bool _isInAttackRange = false;
    private Transform _currentEnemy;
    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _currentWarPoint;

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

    public void ReachThePosition()
    {
        _currentWarPoint = _soldier.transform.DOMove(_soldier.WarPoint.position, _durationForPosition);
    }

    public Transform CurrentAim()
    {
        return _currentEnemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("увидел врага");

            _isInAttackRange = true;
            DOTween.KillAll();
            _currentEnemy = other.transform;
        }

    }
}
