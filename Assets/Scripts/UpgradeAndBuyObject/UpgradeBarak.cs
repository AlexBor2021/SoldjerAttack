using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBarak : BuyAndUpgrade
{
    [SerializeField] private List<GameObject> _upgrades;
    [SerializeField] private Spawner _spawner;

    private GameObject _currentBarak;

    private void Start()
    {
        _currentBarak = _upgrades[0];
    }

    protected override void OffObject()
    {
        gameObject.SetActive(false);
    }

    protected override void UpgradeObject()
    {
        _currentBarak.SetActive(false);
        _currentBarak = _upgrades[_currentLevelUpgrade-1];
        _currentBarak.SetActive(true);
        _spawner.Upgrade();
    }
}
