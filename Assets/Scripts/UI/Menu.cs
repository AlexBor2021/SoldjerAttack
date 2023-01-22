using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MoverPlayer _moverPlayer;

    public void Play()
    {
        _moverPlayer.enabled = true;
    }
}
