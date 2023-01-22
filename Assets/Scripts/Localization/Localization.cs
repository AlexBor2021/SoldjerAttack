using UnityEngine;
using UnityEngine.Localization.Settings;

public class Localization  : MonoBehaviour
{
    public void SetEn()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void SetRus()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }
}