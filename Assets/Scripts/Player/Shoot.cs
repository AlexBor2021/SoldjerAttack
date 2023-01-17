using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _effectShoot;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _positionRaycast;

    private Enemy _enemy;
    private Coroutine _damageTakeCor;
    private bool _isShoot;


    private void OnEnable()
    {
        _effectShoot.Stop();
    }
    private void FixedUpdate()
    {
        //Ray _ray = new Ray(_positionRaycast.position, Vector3.forward);
        //Physics.Raycast(_ray, out RaycastHit _raycastHit, 4f);

        Vector3 forvard = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forvard, Color.red);

        //_raycastHit.collider.TryGetComponent(out Enemy enemy);

        //if (enemy == _enemy && _enemy != null)
        //{
        //    _isShoot = true;
        //    Debug.Log(1);
        //}
        //else
        //{
        //    _isShoot = false;
        //    Debug.Log(2);
        //}
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
            _player.transform.LookAt(_enemy.transform.position);
            if (_isShoot)
            {
                _enemy.TakeDamage(_damage);
                _effectShoot.Play();
            }
            yield return new WaitForSeconds(1.5f);
        }

        _enemy = null;
        yield return null;
    }
}
