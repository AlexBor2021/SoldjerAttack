using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private TextMeshProUGUI _textLevel;

    private int _coast = 200;
    private int _level = 1;
    private MoverPlayer _player;
    private BarGold _money;

    private void OnEnable()
    {
        if (DataGame.InfoLevel.LoadPowerPlayerLevel() > 0)
        {
            _coast = DataGame.InfoLevel.LoadPowerPlayerPrise();
            _level = DataGame.InfoLevel.LoadPowerPlayerLevel();
        }
        _player = FindObjectOfType<MoverPlayer>();
        _money = FindObjectOfType<BarGold>();

        _textCost.text = _coast.ToString();
        _textLevel.text = _level.ToString();
    }

    public void UpdateSpeed()
    {
        if (_money.GoldCount >= _coast)
        {
            _money.GiveGald(_coast);
            _player.UppSpeed(1);
            _coast += 100;

            _textCost.text = _coast.ToString();
            _textLevel.text = _level.ToString();

            DataGame.InfoLevel.SavePowerPlayerLevelandPrise(_level, _coast);
        }
    }
}
