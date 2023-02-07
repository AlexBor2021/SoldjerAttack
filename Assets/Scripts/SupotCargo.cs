using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupotCargo : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCargo;
    [SerializeField] private ParticleSystem _effectCreate;

    private Transform _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    public void CreateCargo()
    {
        Vector3 position = new Vector3(_player.position.x+Random.Range(-3, 3), _player.position.y, _player.position.z + Random.Range(2, 5));

        Instantiate(_effectCreate, position, Quaternion.identity);
        Instantiate(_prefabCargo, position, Quaternion.identity);
    }


}
