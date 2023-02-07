using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _superPlayer;
    [SerializeField] private GameObject _playerEssy;
    [SerializeField] private int _timeSuperPlayer;
    [SerializeField] private AudioMixer _audioMixer;

    private bool _isSuperPlayer;
    private const string _offSuperPlayer = "OffSuperPlayer";
    private const string _masterSound = "MasterSound";

    public void SwitshSuperPlayer()
    {
        VideoAd.Show(OffMusicVolume, Revard, OnMusicVolume);

        void OffMusicVolume()
        {
            Time.timeScale = 0;
            _audioMixer.SetFloat(_masterSound, -80);
        }
        void OnMusicVolume()
        {
            Time.timeScale = 1;
            _audioMixer.SetFloat(_masterSound, 0);
        }

        void Revard()
        {
            if (_isSuperPlayer == false)
            {
                _isSuperPlayer = true;
                _playerEssy.SetActive(false);
                _superPlayer.SetActive(true);
                Invoke(_offSuperPlayer, _timeSuperPlayer);
            }
        }
    }

    private void OffSuperPlayer()
    {
        _isSuperPlayer = false;
        _playerEssy.SetActive(true);
        _superPlayer.SetActive(false);
    }

    
}
