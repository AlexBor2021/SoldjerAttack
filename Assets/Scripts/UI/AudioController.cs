using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float _currentAudioValue;

    private void Awake()
    {
        _currentAudioValue = 1;
    }

    public void MuteAudio()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void AudioSlider(float value)
    {
        AudioListener.volume = value;
        Debug.Log(AudioListener.volume);
    }

    private void OnApplicationFocus(bool focus)
    {
        
        if (focus)
        {
            AudioListener.volume = _currentAudioValue;
        }
        else
        {
            _currentAudioValue = AudioListener.volume;
            AudioListener.volume = 0;
        }
    }
}
