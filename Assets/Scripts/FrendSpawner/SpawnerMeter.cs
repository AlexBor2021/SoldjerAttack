using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnerMeter : MonoBehaviour
{
    [SerializeField] private Image _fildImage;
    [SerializeField] private TextMeshProUGUI _levelSpawner;

    private int _levelSpawnerNumber = 1;
    private float _timeFild;
    private float _curentTime = 0;
    private float _number;
    private bool _isStop;

    private void Update()
    {
        if (_isStop == false)
        {
            _curentTime += Time.deltaTime;

            _number = Mathf.InverseLerp(0, _timeFild, _curentTime);
            _fildImage.fillAmount = _number;

            if (_curentTime >= _timeFild)
            {
                _curentTime = 0;
                _fildImage.fillAmount = 0;
            }
        }
        else
        {
            _curentTime = 0;
            _fildImage.fillAmount = 0;
        }
    }

    public void SwitchMeter(bool isStop)
    {
        _isStop = isStop;
    }

    public void SetMeterDalay(float dalay)
    {
        _timeFild = dalay;
    }

    public void UpLevel()
    {
        _levelSpawnerNumber++;
        _levelSpawner.text = _levelSpawnerNumber.ToString();
    }
}
