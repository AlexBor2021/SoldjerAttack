using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    public abstract event Action OnDie;
    public abstract void TakeDamage();

}
