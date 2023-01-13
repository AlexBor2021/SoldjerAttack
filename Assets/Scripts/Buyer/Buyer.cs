using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buyer : MonoBehaviour
{
    [SerializeField] private int _prise;
    [SerializeField] private TextMeshProUGUI _priseText;
    [SerializeField] private TextMeshProUGUI _moneyTaking;
    [SerializeField] private GameObject _objectBuy;

    private int _takeMoney;
    private BagMoney _bagMoney;

    private void Start()
    {
        _priseText.text = _prise.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BagMoney>(out _bagMoney))
        {
            _bagMoney.TakeMoney(transform, _prise, this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BagMoney>(out _bagMoney))
        {
            _bagMoney.StopTakeMoney();
        }
    }

    public void CameMoney()
    {
        _takeMoney++;

        _moneyTaking.text = _takeMoney.ToString();

        if (_takeMoney == _prise)
        {
            _objectBuy.SetActive(true);
            gameObject.SetActive(false);
            _bagMoney.StopTakeMoney();
        }
    }
}
