using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class BuyAndUpgrade : MonoBehaviour
{
    [SerializeField] protected int _prise;
    [SerializeField] protected TextMeshProUGUI _priseText;
    [SerializeField] protected TextMeshProUGUI _moneyTaking;
    [SerializeField] protected GameObject _objectBuy;
    [SerializeField] protected List<int> _priseUpgrade;
    [SerializeField] protected Transform _placeMoveMoney;
    [SerializeField] protected AudioSource _upSound;
    [SerializeField] protected Image _imageFiild;

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

        FildImage(_takeMoney);

        if (_takeMoney == _prise && _objectBuy.activeSelf == false)
        {
            _bagMoney.StopTakeMoney();
            _objectBuy.SetActive(true);
            _prise = 0;
            _takeMoney = 0;
            _upSound.Play();
        }
        else if(_priseUpgrade.Count > 0 && _objectBuy.activeSelf)
        {
            if (_takeMoney == _priseUpgrade[0])
            {
                _bagMoney.StopTakeMoney();
                _takeMoney = 0;
                _priseUpgrade.RemoveAt(0);
                _currentLevelUpgrade++;
                UpgradeObject();
                _upSound.Play();
            }
        }
        if (_priseUpgrade.Count == 0 && _objectBuy.activeSelf)
        {
            OffObject();
        }

        _moneyTaking.text = _takeMoney.ToString();
    }

    private void TakeMoneyFromBag()
    {
        _bagMoney.StopTakeMoney();

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

    private void FildImage(float value)
    {
        float number;
        if (_prise != 0)
        {
            number = Mathf.InverseLerp(0, _prise, value);
        }
        else
        {
            number = Mathf.InverseLerp(0, _priseUpgrade[0], value);
        }
        _imageFiild.fillAmount = number;
    }

    protected abstract void UpgradeObject();
    protected abstract void OffObject();
}
