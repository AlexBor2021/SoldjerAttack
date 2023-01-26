using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackState : State
{
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private Soldier _soldier;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _effectShoot;

    private Coroutine _shootCorotine = null;
    
    public Enemy _currentAim;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }

    public override State RunCurrentState()
    {
        if (_currentAim == null)
        {
            if (_shootCorotine!= null)
            {
                StopCoroutine(_shootCorotine);
            }
            _chaseState._isInAttackRange = false;
            _animator.SetBool("Run", true);
            return _chaseState;
        }
        _animator.SetBool("Run", false);
        return this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == _currentAim)
            {
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
            _soldier.transform.LookAt(_currentAim.transform.position);
            _currentAim.TakeDamage(_soldier.Damage);
            _effectShoot.Play();

            yield return new WaitForSeconds(1f);
        }
        _currentAim = null;
        _shootCorotine = null;
        yield return null;
    }
}
