using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgardePlayer : BuyAndUpgrade
{
    [SerializeField] private SkinPlayerUograde _skinPlayerUograde;
    protected override void OffObject()
    {
        gameObject.SetActive(false);
    }

    protected override void UpgradeObject()
    {
        _skinPlayerUograde.Upgrade(_currentLevelUpgrade);
    }
}
