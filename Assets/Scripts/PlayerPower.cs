using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    private MoverPlayer _player;

    private void Start()
    {
        _player = FindObjectOfType<MoverPlayer>();
    }

    public void UpdateSpeed()
    {
        _player.UppSpeed(1);
    }
}
