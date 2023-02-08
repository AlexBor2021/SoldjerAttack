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
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();

        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);

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
