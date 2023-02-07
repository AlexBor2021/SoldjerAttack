using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarGold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gold;

    private int _goldCount;

    public void TakeGold(int number)
    {
        _goldCount += number;
        _gold.text = _goldCount.ToString();
    }

    public void GiveGald(int number)
    {
        _goldCount -= number;
        _gold.text = _goldCount.ToString();
    }
}
