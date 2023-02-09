using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MoverPlayer _moverPlayer;

    private void OnEnable()
    {
        _moverPlayer.enabled = false;
    }

    public void StartGame()
    {
        _moverPlayer.enabled = true;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
