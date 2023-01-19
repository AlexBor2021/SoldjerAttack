using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarMoney : MonoBehaviour
{
    [SerializeField] private BagMoney _bagMoney;
    [SerializeField] private TextMeshProUGUI _money;

    private void OnEnable()
    {
        _bagMoney.ChengedBAgMoney += SetInfoBarMoney;
    }
    private void OnDisable()
    {
        _bagMoney.ChengedBAgMoney -= SetInfoBarMoney;
    }

    private void SetInfoBarMoney(int countmoney)
    {
        _money.text = countmoney.ToString();
    }

}
