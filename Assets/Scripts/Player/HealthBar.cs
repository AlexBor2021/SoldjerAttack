using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slader;
    [SerializeField] private Soldier _player;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _slader.maxValue = (float)_player.Health;
        _slader.value = (float)_player.Health;
    }

    private void Update()
    {
        if (_player.Health != _slader.value)
        {
            _slader.value = _player.Health;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }

}
