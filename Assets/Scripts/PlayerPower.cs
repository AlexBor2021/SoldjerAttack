using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _coast = 200;
    private float _moneyValue;
    private MoverPlayer _player;
    private BarGold _money;

    private void Start()
    {
        _player = FindObjectOfType<MoverPlayer>();
        _money = FindObjectOfType<BarGold>();

        _text.text = _coast.ToString();
    }

    public void UpdateSpeed()
    {
        if (_money.GoldCount >= _coast)
        {
            _coast += 100;
            _text.text = _coast.ToString();

            _player.UppSpeed(1);
            _money.GiveGald(_coast);
        }
    }
}
