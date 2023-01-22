using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotForSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pointForBots;
    [SerializeField] private int _currentLvl;
    [SerializeField] private AllEnemySpawns _warPoints;

    private int _indexPoint = 0;
    private List<Transform> _activePointForBots = new();
    private List<Soldier> _compliteSoldiers = new();

    private void Awake()
    {
        InitPointForBots();
    }

    private void InitPointForBots()
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
        _compliteSoldiers.Add(character);

        character.SetStartPoint(_activePointForBots[_indexPoint],_warPoints.CurrentPointOfAttack());
        _indexPoint++;
    }

    public void SignalOnWar()
    {
        for (int i = 0; i < _compliteSoldiers.Count; i++)
        {
            _compliteSoldiers[i].GetComponentInChildren<IdleState>()._isInAttack = true;
        }
        _compliteSoldiers.Clear();
        _indexPoint = 0;
    }
}
