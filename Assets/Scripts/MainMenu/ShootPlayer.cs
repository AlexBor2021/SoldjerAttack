using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particles;
    [SerializeField] private ParticleSystem _shootEffect;

    private Coroutine _shoot;

    private void OnEnable()
    {
        _shootEffect.Stop();

        foreach (var item in _particles)
        {
            item.Stop();
        }

        _shoot = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            _shootEffect.Play();

            _particles[Random.Range(0, _particles.Count-1)].Play();

            yield return new WaitForSeconds(1);
        }

        yield return null;
    }

    private void OnDisable()
    {
        StopCoroutine(_shoot);
    }
}
