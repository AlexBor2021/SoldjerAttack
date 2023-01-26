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
        _time += Time.deltaTime;

        if (_time >= _delay)
        {
            SpawnCharacter();
            _time = 0;
        }
    }

    private void SpawnCharacter()
    {
       int countFreeSpace = _spotForSpawn.GetAmountFreeSpace();

        if (countFreeSpace > 0)
        {
            _spotForSpawn.SetSpawnedCharacter(Instantiate(_character, transform.position, Quaternion.identity));
        }
    }

    public void Upgrade()
    {
        _delay--;
    }
}
