using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarGold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gold;

    private int _goldCount = 400;
    public int GoldCount => _goldCount;

    private void Start()
    {
        _gold.text = _goldCount.ToString();
    }
    public void TakeGold(int number)
    {
        _goldCount += number;
        _gold.text = _goldCount.ToString();
    }

    public void GiveGald(int number)
    {
        Debug.Log("улучшил");
        _goldCount -= number;
        _gold.text = _goldCount.ToString();
    }
}
