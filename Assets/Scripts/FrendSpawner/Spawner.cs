using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Spawner : MonoBehaviour
{
    [SerializeField] private Soldier _character;
    [SerializeField] private float _delay;
    [SerializeField] SpotForSpawn _spotForSpawn;
    [SerializeField] SpawnerMeter _spawnerMeter;

    private float _time;

    private void OnEnable()
    {
        _spawnerMeter.SetMeterDalay(_delay);
    }

    private void Update()
    {
        int countFreeSpace = _spotForSpawn.GetAmountFreeSpace();

        if (countFreeSpace > 0)
        {
            _time += Time.deltaTime;

            if (_time >= _delay)
            {
                SpawnCharacter();
                _time = 0;
            }
        }
        else
        {
            _time = 0;
            _spawnerMeter.SwitchMeter(true);
        }
        
    }

    private void SpawnCharacter()
    {
        _spawnerMeter.SwitchMeter(false);
        _spotForSpawn.SetSpawnedCharacter(Instantiate(_character, transform.position, Quaternion.identity));
    }

    public void Upgrade()
    {
        _delay--;
    }
}
