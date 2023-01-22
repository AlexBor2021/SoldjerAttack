using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlayerUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject _levelOne;
    [SerializeField] private GameObject _levelTwo;
    [SerializeField] private GameObject _levelTherd;
    
    private GameObject _currentLevel;

    private void OnEnable()
    {
        _currentLevel = _levelOne;
    }

    public void Upgrade(int numberLevel)
    {
        _currentLevel.SetActive(false);

        switch (numberLevel)
        {
            case 2:
                _currentLevel = _levelTwo;
                break;
            case 3:
                _currentLevel = _levelTherd;
                break;
            default:
                _currentLevel = _levelOne;
                break;
        }

        _currentLevel.SetActive(true);
    }
}
