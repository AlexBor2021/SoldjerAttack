using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnenmy : State
{
    [SerializeField] private ChaseEnemy _chaseState;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _effectShoot;

    private Coroutine _shootCorotine = null;
    private Soldier _currentAim;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }

    public override State RunCurrentState()
    {
        if (_currentAim == null)
        {
            if (_shootCorotine != null)
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

    public void SetAimForAttack(Soldier soldier)
    {
        _currentAim = soldier;
        _shootCorotine = StartCoroutine(TakeDamage());
    }

    public IEnumerator TakeDamage()
    {
        while (_currentAim.Health > 0)
        {
            _enemy.transform.LookAt(_currentAim.transform.position);
            _currentAim.TakeDamage(_enemy.Damage);
            _effectShoot.Play();

            yield return new WaitForSeconds(1f);
        }

        _chaseState.OffAim();
        _currentAim = null;
        _shootCorotine = null;
        yield return null;
    }
}
