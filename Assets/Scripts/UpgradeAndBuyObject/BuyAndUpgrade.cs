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
    [SerializeField] protected AudioSource _upSound;

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
        if (other.TryGetComponent<BagMoney>(out BagMoney bagMoney))
        {
            _bagMoney = bagMoney;
            TakeMoneyFromBag();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BagMoney>(out BagMoney bagMoney))
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
            _bagMoney.StopTakeMoney();
            _objectBuy.SetActive(true);
            _prise = 0;
            _takeMoney = 0;
            TakeMoneyFromBag();
            _upSound.Play();
        }
        else if(_priseUpgrade.Count > 0 && _objectBuy.activeSelf)
        {
            if (_takeMoney == _priseUpgrade[0])
            {
                if (_bagMoney != null)
                    _bagMoney.StopTakeMoney();
                _takeMoney = 0;
                _priseUpgrade.RemoveAt(0);
                TakeMoneyFromBag();
                _currentLevelUpgrade++;
                UpgradeObject();
                _upSound.Play();
            }
        }
    }

    public bool CheckIsUpgrade()
    {
        if (_priseUpgrade.Count <= 0)
        {
            OffObject();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TakeMoneyFromBag()
    {
        if (_prise > 0)
        {
            _bagMoney.TakeMoney(_placeMoveMoney, _prise, this);
        }
        else if(_priseUpgrade.Count > 0)
        {
            _bagMoney.TakeMoney(_placeMoveMoney, _priseUpgrade[0], this);
            _priseText.text = _priseUpgrade[0].ToString();
        }
    }

    protected abstract void UpgradeObject();
    protected abstract void OffObject();
}
