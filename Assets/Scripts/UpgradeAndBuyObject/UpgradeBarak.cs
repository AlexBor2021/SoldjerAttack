using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBarak : BuyAndUpgrade
{
    protected override void OffObject()
    {
        gameObject.SetActive(false);
    }

    protected override void UpgradeObject()
    {
        
    }
}
