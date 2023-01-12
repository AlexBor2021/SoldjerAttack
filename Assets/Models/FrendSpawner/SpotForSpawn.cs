using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotForSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointForBots;
    private int _indexPoint = 0;
   
    private void Start()
    {
        
    }
    public int GetAmountFreeSpace()
    {
        return _pointForBots.Count - _indexPoint;
    }

    public void SetSpawnedCharacter(Soldier character)
    {
        character.GetStartPoint(_pointForBots[_indexPoint]);
        _indexPoint++;
    }
}
