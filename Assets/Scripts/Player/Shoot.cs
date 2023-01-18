using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _effectShoot;
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody _playeRb;

    private Enemy _enemy;
    private Coroutine _damageTakeCor;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }

    private void FixedUpdate()
    {
        if (_playeRb.velocity.magnitude > 2)
        {
            _effectShoot.Stop();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_enemy == null && enemy.Health > 0)
            {
                _enemy = enemy;
                _damageTakeCor = StartCoroutine(TakeDamage());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() == _enemy && _enemy != null)
        {
            StopCoroutine(_damageTakeCor);
            _enemy = null;
        }
    }

    private IEnumerator TakeDamage()
    {
        while (_enemy.Health > 0)
        {
            if (_playeRb.velocity.magnitude < 2)
            {
                _player.transform.LookAt(_enemy.transform.position);
                _enemy.TakeDamage(_damage);
                _effectShoot.Play();
            }

            yield return new WaitForSeconds(1f);
        }

        _enemy = null;
        yield return null;
    }
}
