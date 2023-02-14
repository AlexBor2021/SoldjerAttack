using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private GameObject _cameraUp;

    private void OnEnable()
    {
        _cameraUp = GameObject.FindGameObjectWithTag("CameraUp");
        _cameraUp.SetActive(false);
    }

    public void Click()
    {
        if (_cameraUp.activeSelf)
        {
            _cameraUp.SetActive(false);
        }
        else
        {
            _cameraUp.SetActive(true);
        }
    }
}
