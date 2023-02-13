using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Agava.YandexGames;

public class GeneralMarketing : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private FinishMenu _finishMenu;
    
    private Player _player;
    private const string _masterSound = "MasterVolume";

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
    }

    public void ShowInstalateForCoinX2()
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
            _finishMenu.RevardForLevel();
        }
    }

    public void ShowBaner()
    {
        InterstitialAd.Show(OffMusicVolume, OnMusicVolume, OnError);

        void OffMusicVolume()
        {
            Time.timeScale = 0;
            _audioMixer.SetFloat(_masterSound, -80);
        }
        void OnMusicVolume(bool close)
        {
            Time.timeScale = 1;
            _audioMixer.SetFloat(_masterSound, 0);
        }

        void OnError(string error)
        {
            Debug.Log(error);
        }
    }

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
            _player.SuperPlaer();
        }
    }
}
