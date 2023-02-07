using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraForShowEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _moveCamera;
    [SerializeField] private MoverPlayer _moverPlayer;
    [SerializeField] private int _speed;

    private int _numberPoint = 0;
    private const string _offObject = "OffObject";

    private void OnEnable()
    {
        _moverPlayer.enabled = false;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_numberPoint].position, _speed * Time.deltaTime);

        if (transform.position == _points[_numberPoint].position)
        {
            if (_numberPoint < _points.Count - 1)
                _numberPoint++;
            else
                Invoke(_offObject, 3f);
        }
    }

    private void OffObject()
    {
        _moverPlayer.enabled = true;
        _moveCamera.SetActive(false);
    }
}
