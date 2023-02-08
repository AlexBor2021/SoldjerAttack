using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKIntialize : MonoBehaviour
{
    public bool InputSystemKeyBoard;


    private IEnumerator Start()
    {
        DontDestroyOnLoad(this.gameObject);

#if UNITY_WEBGL && YANDEX_GAMES && !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
#else
        SceneManager.LoadScene(1);
#endif
        yield return null;

        InputSystemKeyBoard = SetInputGameKeyBoard();
    }
    public bool SetInputGameKeyBoard()
    {
#if UNITY_WEBGL && YANDEX_GAMES && !UNITY_EDITOR
        return Device.Type == Agava.YandexGames.DeviceType.Desktop;
#endif
        return SystemInfo.deviceType == UnityEngine.DeviceType.Desktop;
    }
}
