using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgardePlayer : BuyAndUpgrade
{
    [SerializeField] private SkinPlayerUpgrade _skinPlayerUograde;
    protected override void OffObject()
    {
        gameObject.SetActive(false);
    }

    protected override void UpgradeObject()
    {
        _skinPlayerUograde.Upgrade(_currentLevelUpgrade);
    }
}
