using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BagMoney : MonoBehaviour
{
    [SerializeField] private Transform _contaner;
    [SerializeField] private List<Money> _moneys;
    [SerializeField] private float _heightDiference = 0.15f;

    private float _heightY = 0;
    private Coroutine _takemoney;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Money>(out Money money))
        {
            if (money.IsCollect == false)
            {
                GiveMoney(money);
            }
        }
    }
    public void StopTakeMoney()
    {
        StopCoroutine(_takemoney);
    }
    public void TakeMoney(Transform parent, int price, Buyer buyer)
    {
        _takemoney = StartCoroutine(TakingMoney(parent, price, buyer));
    }

    private IEnumerator TakingMoney(Transform parent, int price, Buyer buyer)
    {
            while (_moneys.Count != 0)
            {
                for (int i = 0; i < price; i++)
                {
                    _moneys[_moneys.Count-1].Moving(parent);
                    _moneys.RemoveAt(_moneys.Count - 1);
                    _heightY -= _heightDiference;

                    buyer.CameMoney();

                    if (_moneys.Count == 0)
                    {
                        StopCoroutine(_takemoney);
                        break;
                    }

                    yield return new WaitForSeconds(0.5f);
                }
            }

        yield return null;
    }
    private void GiveMoney(Money money)
    {
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
            _heightY += _heightDiference;
        }
    }

}
