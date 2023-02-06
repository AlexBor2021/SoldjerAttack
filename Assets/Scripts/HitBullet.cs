using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBullet : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particals;

    private void OnEnable()
    {
        foreach (var item in _particals)
        {
            item.Stop();
        }
    }

    public void SetHitBullet()
    {
        _particals[Random.Range(0, _particals.Count - 1)].Play();
    }
}
