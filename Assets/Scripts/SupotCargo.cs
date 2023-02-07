using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Audio;

public class SupotCargo : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCargo;
    [SerializeField] private ParticleSystem _effectCreate;
    [SerializeField] private AudioMixer _audioMixer;

    private Transform _player;
    private const string _masterSound = "MasterSound";

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    public void CreateCargo()
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
            Vector3 position = new Vector3(_player.position.x + Random.Range(-3, 3), _player.position.y, _player.position.z + Random.Range(2, 5));

            Instantiate(_effectCreate, position, Quaternion.identity);
            Instantiate(_prefabCargo, position, Quaternion.identity);
        }
    }


}
