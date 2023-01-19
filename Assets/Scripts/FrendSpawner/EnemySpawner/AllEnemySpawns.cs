using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemySpawns : MonoBehaviour
{
    [SerializeField] private List<Transform> _allEnemySpawns;

 
    public Transform CurrentPointOfAttack()
    {
        return _allEnemySpawns[0];
    }

}
