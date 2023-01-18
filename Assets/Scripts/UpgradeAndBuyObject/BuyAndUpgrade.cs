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

    private int _takeMoney;
    private BagMoney _bagMoney;
    private int _currentLevelUpgrade = 1;

    private void Start()
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
            _bagMoney.TakeMoney(_placeMoveMoney, _prise, this);
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
            RebootAfterBuy();
        }
        else if (_takeMoney == _priseUpgrade[0])
        {
            _priseUpgrade.RemoveAt(0);
            RebootAfterBuy();
            UpgradeObject();
        }
        else if (_priseUpgrade.Count == 0)
        {
            OffObject();
        }
    }

    private void RebootAfterBuy()
    {
        _bagMoney.StopTakeMoney();
        _priseText.text = _priseUpgrade[0].ToString();
        _takeMoney = 0;
    }

    protected abstract void UpgradeObject();

    protected abstract void OffObject();
    
}
