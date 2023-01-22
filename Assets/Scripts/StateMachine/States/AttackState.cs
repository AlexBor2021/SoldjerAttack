using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackState : State
{
    [SerializeField] ChaseState _chaseState;
    [SerializeField] Soldier _soldier;

    public Enemy _currentAim;
    private bool _searchEnemy;
    private Coroutine _shootCorotine = null;

    public override State RunCurrentState()
    {
        if (_currentAim == null)
        {
            if (_shootCorotine!= null)
            {
                StopCoroutine(_shootCorotine);
            }
            _chaseState._isInAttackRange = false;
            return _chaseState;
        }
        return this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == _currentAim)
            {
                _chaseState._comingInEnemy.Kill();
                Debug.Log("нашел цель");

                if (_shootCorotine == null)
                {
                    _shootCorotine = StartCoroutine(TakeDamage());
                }
            }
        }
    }

    private IEnumerator TakeDamage()
    {
        while (_currentAim.Health > 0)
        {
            Debug.Log("Стрелять");
            _soldier.transform.LookAt(_currentAim.transform.position);
            _currentAim.TakeDamage(_soldier.Damage);
          //  _effectShoot.Play();

            yield return new WaitForSeconds(1f);
        }
        _currentAim = null;
        Debug.Log("убил");
        _shootCorotine = null;
        yield return null;
    }
}
