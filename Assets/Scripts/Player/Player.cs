using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _superPlayer;
    [SerializeField] private GameObject _playerEssy;
    [SerializeField] private int _timeSuperPlayer;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Image _imageTimer;
    [SerializeField] private Image _imageTimerIn;

    private bool _isSuperPlayer;
    private const string _offSuperPlayer = "OffSuperPlayer";
    private Coroutine _timerPLayerSuper;
    private float _timeForTimer;

    private void OnEnable()
    {
        _timeForTimer = _timeSuperPlayer;
    }

    public void SuperPlaer()
    {
        if (_isSuperPlayer == false)
        {
            _isSuperPlayer = true;
            _playerEssy.SetActive(false);
            _superPlayer.SetActive(true);
            _timerPLayerSuper = StartCoroutine(TimerPlayerSuper());
            Invoke(_offSuperPlayer, _timeSuperPlayer);
        }
    }

    private IEnumerator TimerPlayerSuper()
    {
        while (true)
        {
            _timeForTimer-= 0.2f;
            _imageTimer.fillAmount = Mathf.InverseLerp(_timeSuperPlayer, 0, _timeForTimer);
            _imageTimerIn.fillAmount = Mathf.InverseLerp(_timeSuperPlayer, 0, _timeForTimer);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OffSuperPlayer()
    {
        StopCoroutine(_timerPLayerSuper);
        _isSuperPlayer = false;
        _playerEssy.SetActive(true);
        _superPlayer.SetActive(false);
    }
}
