using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerMeter : MonoBehaviour
{
    [SerializeField] private Image _fildImage;
    [SerializeField] private BuyAndUpgrade _barak;

    private float _timeFild;
    private Coroutine _stratMeter;

    private void Update()
    {
        _fildImage.fillAmount = Mathf.MoveTowards(0, 1, 4);

        if (_fildImage.fillAmount == 1)
        {
            _fildImage.fillAmount = 0;
        }
    }
}
