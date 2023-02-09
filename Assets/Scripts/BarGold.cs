using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarGold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gold;

    public static BarGold Instance { get; private set; }

    private int _goldCount;
    public int GoldCount => _goldCount;

    private void OnEnable()
    {
        _goldCount = DataGame.Gold.LoadGold();
        _gold.text = _goldCount.ToString();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void TakeGold(int number)
    {
        _goldCount += number;
        _gold.text = _goldCount.ToString();
        DataGame.Gold.SaveGold(_goldCount);
    }

    public void GiveGald(int number)
    {
        _goldCount -= number;
        _gold.text = _goldCount.ToString();
        DataGame.Gold.SaveGold(_goldCount);
    }
}
