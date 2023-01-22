using UnityEngine;
using UnityEngine.Audio;
using Agava.WebUtility;

public class SoundOutSideGame1 : MonoBehaviour
{
    [SerializeField] private AudioMixer _master;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OffSoundInGame;
    }
    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OffSoundInGame;
    }

    public void OffSoundInGame(bool enable)
    {
        if (enable)
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
            _master.SetFloat("Master", -80);
        }
        else
        {
            AudioListener.pause = false;
            AudioListener.volume = 1;
            _master.SetFloat("Master", 0);
        }
    }
}
