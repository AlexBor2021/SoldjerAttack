using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BagMoney : MonoBehaviour
{
    [SerializeField] private Transform _contaner;
    [SerializeField] private List<Money> _moneys;
    [SerializeField] private float _heightDiference = 0.15f;
    [SerializeField] private AudioSource _moneySound;

    private float _heightY = 0;
    private Coroutine _takemoney;

    public event UnityAction<int> ChengedBAgMoney;

    private void OnEnable()
    {
        ChengedBAgMoney?.Invoke(_moneys.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Money>(out Money money))
        {
            if (money.IsCollect == false)
                GiveMoney(money);
        }
    }
    public void StopTakeMoney()
    {
        if (_takemoney != null)
            StopCoroutine(_takemoney);
    }
    public void TakeMoney(Transform _placeMoveMoney, int price, BuyAndUpgrade buyAndUpgrade)
    {
        _takemoney = StartCoroutine(TakingMoney(_placeMoveMoney, price, buyAndUpgrade));
    }

    private IEnumerator TakingMoney(Transform parent, int price, BuyAndUpgrade buyAndUpgrade)
    {
        while (_moneys.Count != 0)
        {
            for (int i = 0; i < price; i++)
            {
                if (_moneys.Count != 0)
                {
                    _moneys[_moneys.Count - 1].Moving(parent);
                }
                
                _moneys.RemoveAt(_moneys.Count - 1);
                ChengedBAgMoney?.Invoke(_moneys.Count);
                _heightY -= _heightDiference;

                buyAndUpgrade.CameMoney();

                if (_moneys.Count == 0 || buyAndUpgrade.CheckIsUpgrade())
                    StopTakeMoney();
               
                yield return new WaitForSeconds(0.3f);
            }
        }

        yield return null;
    }
    private void GiveMoney(Money money)
    {
        _moneySound.Play();

        money.transform.SetParent(_contaner);

        if (_moneys.Count == 0)
        {
            money.transform.DOJump(_contaner.position, 3f, 1, 0.2f).OnComplete(SetParent);
        }
        else
        {
            money.transform.DOJump(_moneys[_moneys.Count - 1].transform.position, 3f, 1, 0.2f).OnComplete(SetParent);
        }

        void SetParent()
        {
            money.transform.localPosition = new Vector3(0, _heightY, 0);
            money.transform.localRotation = Quaternion.identity;

            money.IsCollect = true;
            _moneys.Add(money);
            ChengedBAgMoney?.Invoke(_moneys.Count);
            _heightY += _heightDiference;
        }
    }

}
