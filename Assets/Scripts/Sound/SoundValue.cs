using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundValue : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _music;
    [SerializeField] private AudioMixerGroup _effects;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Image _musicOn;
    [SerializeField] private Image _musicOff;
    [SerializeField] private Image _effectsOn;
    [SerializeField] private Image _effectsOff;

    private const string _musicVolume = "Music";
    private const string _effectsVolume = "Effect";

    
    public void SetMusicSound()
    {
        Debug.Log(_musicVolume);

        _music.audioMixer.SetFloat(_musicVolume, Mathf.Lerp(-60, 0, _musicSlider.value));

        if (_musicSlider.value > 0)
        {
            _musicOn.enabled = true;
            _musicOff.enabled = false;
        }
        else
        {
            _musicOn.enabled = false;
            _musicOff.enabled = true;
        }
    }
    public void SetEffectSound()
    {
        _effects.audioMixer.SetFloat(_effectsVolume, Mathf.Lerp(-60, 0, _effectsSlider.value));

        if (_effectsSlider.value > 0)
        {
            _effectsOn.enabled = true;
            _effectsOff.enabled = false;
        }
        else
        {
            _effectsOn.enabled = false;
            _effectsOff.enabled = true;
        }
    }
}
