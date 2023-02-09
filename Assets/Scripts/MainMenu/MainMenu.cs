using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _level = 2;
    public void PlayButoon()
    {
        if (DataGame.InfoLevel.LoadInfoLEvel() > 0)
        {
            _level = DataGame.InfoLevel.LoadInfoLEvel();
        }

        SceneManager.LoadScene(_level);
    }
    public void InfoButton()
    {

    }
    public void AboutButton()
    {

    }
}
