using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Agava.YandexGames;

public class GeneralMarketing : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    private const string _masterSound = "MasterVolume";

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

        }
    }

    public void ShowBaner()
    {
        InterstitialAd.Show();
    }
}
