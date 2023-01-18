using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyAndUp : BuyAndUpgrade
{
    [SerializeField] private int _prise;
    [SerializeField] private TextMeshProUGUI _priseText;
    [SerializeField] private TextMeshProUGUI _moneyTaking;
    [SerializeField] private GameObject _objectBuy;
    [SerializeField] private List<int>_priseUpgrade;

    private int _takeMoney;
    private BagMoney _bagMoney;
    private int _currentLevelUpgrade = 1;

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

        if (_takeMoney == _prise && _objectBuy.activeSelf == false)
        {
            _objectBuy.SetActive(true);
            _bagMoney.StopTakeMoney();
            _priseText.text = _priseUpgrade[0].ToString();
            _takeMoney = 0;
        }
        else if(_takeMoney == _priseUpgrade[0])
        {
            _priseUpgrade.RemoveAt(0);
        }
    }

    public void UpgradeObject(int levelUpgrade)
    {

    }
}
