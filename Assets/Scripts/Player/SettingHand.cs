using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingHand : MonoBehaviour
{
    [SerializeField] private Transform _targetLefthand;
    [SerializeField] private Transform _targetRighthand;
    [SerializeField] private Transform _rotateLeft;
    [SerializeField] private Transform _rotateRight;
    void Start()
    {
        _targetLefthand.position = _rotateLeft.position;
        _targetLefthand.rotation = _rotateLeft.rotation;
        _targetRighthand.position = _rotateRight.position;
        _targetRighthand.rotation = _rotateRight.rotation;
    }
}
