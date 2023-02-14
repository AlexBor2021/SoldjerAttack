using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _cameraUp;

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
