using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKIntialize : MonoBehaviour
{
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();

        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);
    }
}
