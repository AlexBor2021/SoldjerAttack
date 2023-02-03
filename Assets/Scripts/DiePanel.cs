using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePanel : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private void OnEnable()
    {
        _music.Pause();
    }

}
