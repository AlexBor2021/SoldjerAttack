using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackState : State
{
    [SerializeField] ChaseState _chaseState;
    [SerializeField] Soldier _soldier;
    private bool _searchEnemy;
    private DG.Tweening.Core.TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _currentAim;

    private void OnEnable()
    {
       _currentAim = _soldier.transform.DOMove(_chaseState.CurrentAim().position,5);
    }

    public override State RunCurrentState()
    {
        if (_searchEnemy)
        {
            return _chaseState;
        }
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("стрелять");

            DOTween.Kill(_currentAim);
        }
    }
}
