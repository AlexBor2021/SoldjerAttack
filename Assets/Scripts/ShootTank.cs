using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTank : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _effectShoot;
    [SerializeField] private Rigidbody _playeRb;
    [SerializeField] private Transform _rotionMain;
    [SerializeField] private AudioSource _shoot;

    private Enemy _enemy;
    private Coroutine _damageTakeCor;
    private float _speedRotation = 12f;

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

        if (_enemy != null)
        {
            var diraction = (_enemy.transform.position - transform.position).normalized;
            Quaternion lookRotathion = Quaternion.LookRotation(new Vector3(diraction.x, 0, diraction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotathion, Time.deltaTime * _speedRotation);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotionMain.rotation, Time.deltaTime * _speedRotation);
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
                _enemy.TakeDamage(_damage);
                _effectShoot.Play();
                _shoot.Play();
            }

            yield return new WaitForSeconds(4f);
        }

        _enemy = null;
        yield return null;
    }
}
