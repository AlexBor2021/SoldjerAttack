using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    public virtual event Action<Health> Die;
    public abstract void TakeDamage(int damage);

}
