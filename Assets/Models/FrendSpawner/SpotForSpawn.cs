using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotForSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointForBots;
    private int _indexPoint = 0;
    private int _currentLvl;
    private void Start()
    {
        
    }
    public int GetAmountFreeSpace()
    {
        switch (_currentLvl)
        {
            case 1:
                return 10 - _indexPoint;

            case 2:
                return 20 - _indexPoint;
            case 3:
                return _pointForBots.Count - _indexPoint;
        }
        return 0;
    }

    public void SetSpawnedCharacter(Soldier character)
    {
        character.GetStartPoint(_pointForBots[_indexPoint]);
        _indexPoint++;
    }
}
