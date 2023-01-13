using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Spawner : MonoBehaviour
{
    [SerializeField] private Soldier _character;
    [SerializeField] private float _delay;
    [SerializeField] SpotForSpawn _spotForSpawn;

    private float _time;

    private void Update()
    {
        if (_time>= _delay)
        {
            SpawnCharacter();
            _time = 0;
        }

        _time += Time.deltaTime;

    }

    private void SpawnCharacter()
    {
       int count = _spotForSpawn.GetAmountFreeSpace();

        if (count> 0)
        {
            _spotForSpawn.SetSpawnedCharacter(Instantiate(_character, transform.position, Quaternion.identity));

        }

    }
    
    
}
