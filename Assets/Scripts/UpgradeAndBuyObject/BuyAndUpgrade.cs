using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BuyAndUpgrade : MonoBehaviour
{
    [SerializeField] protected int _prise;
    [SerializeField] protected TextMeshProUGUI _priseText;
    [SerializeField] protected TextMeshProUGUI _moneyTaking;
    [SerializeField] protected GameObject _objectBuy;
    [SerializeField] protected List<int> _priseUpgrade;
    [SerializeField] protected Transform _placeMoveMoney;

    protected int _takeMoney;
    protected BagMoney _bagMoney;
    protected int _currentLevelUpgrade = 1;

    private void OnEnable()
    {
        if (_prise > 0)
        {
            _priseText.text = _prise.ToString();
        }
        else
        {
            _priseText.text = _priseUpgrade[0].ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BagMoney>(out _bagMoney))
        {
            TakeMoneyFromBag();
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
            _prise = 0;
            TakeMoneyFromBag();
            RebootAfterBuy();
        }
        else if(_priseUpgrade.Count > 0)
        {
            if (_takeMoney == _priseUpgrade[0])
            {
                _currentLevelUpgrade++;
                _priseUpgrade.RemoveAt(0);
                TakeMoneyFromBag();
                RebootAfterBuy();
                UpgradeObject();
            }
        }
        if (_priseUpgrade.Count == 0 && _objectBuy.activeSelf)
        {
            OffObject();
        }
    }

    private void RebootAfterBuy()
    {
        _bagMoney.StopTakeMoney();

        _takeMoney = 0;

        if (_priseUpgrade.Count > 0)
            _priseText.text = _priseUpgrade[0].ToString();
    }

    private void TakeMoneyFromBag()
    {
        if (_prise > 0)
        {
            _bagMoney.TakeMoney(_placeMoveMoney, _prise, this);
        }
        else
        {
            _bagMoney.TakeMoney(_placeMoveMoney, _priseUpgrade[0], this);
        }
        
    }

    protected abstract void UpgradeObject();
    protected abstract void OffObject();
    
}
