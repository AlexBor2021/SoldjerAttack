using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotForSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pointForBots;
    [SerializeField] private int _currentLvl;
    [SerializeField] private Transform _warPoint;

    private int _indexPoint = 0;
    private List<Transform> _activePointForBots = new();

    private void Awake()
    {
        InintPointForBots();
    }

    private void InintPointForBots()
    {
        for (int i = 0; i < _pointForBots[_currentLvl].transform.childCount; i++)
        {
            _activePointForBots.Add(_pointForBots[_currentLvl].transform.GetChild(i));
        }
    }

    public int GetAmountFreeSpace()
    {
        return _activePointForBots.Count - _indexPoint;
    }

    public void SetSpawnedCharacter(Soldier character)
    {
        character.SetStartPoint(_activePointForBots[_indexPoint],_warPoint);
        _indexPoint++;
    }
}
