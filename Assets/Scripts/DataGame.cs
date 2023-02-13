using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataGame 
{
    public class Gold
    {
        public static string GoldCurrentValue = "GoldCurrentValue";
        
        public static void SaveGold(int number)
        {
            PlayerPrefs.SetInt(GoldCurrentValue, number);
        }
        public static int LoadGold()
        {
            return PlayerPrefs.GetInt(GoldCurrentValue);
        }
    }

    public class InfoLevel
    {
        public static string PowerPlayerLevel = "PowerPlayerLevel";
        public static string PowerPlayerPrise = "PowerPlayerPrise";
        public static string CuurentLevel = "CuurentLevel";

        public static void SaveInfoLevel(int numberLevel)
        {
            PlayerPrefs.SetInt(CuurentLevel, numberLevel);
        }
        public static int LoadInfoLEvel()
        {
            return PlayerPrefs.GetInt(CuurentLevel);
        }
        public static void SavePowerPlayerLevelandPrise(int level, int price)
        {
            PlayerPrefs.SetInt(PowerPlayerLevel, level);
            PlayerPrefs.SetInt(PowerPlayerPrise, price);
        }
        public static int LoadPowerPlayerLevel()
        {
            return PlayerPrefs.GetInt(PowerPlayerLevel);
        }
        public static int LoadPowerPlayerPrise()
        {
            return PlayerPrefs.GetInt(PowerPlayerPrise);
        }
    }

    public class SettingsPlayer
    {
        public static string ValueMusic = "ValueMusic";
        public static string ValueEffect = "ValueEffect";

        public static void SaveValueMusic(float valueMusic)
        {
            PlayerPrefs.SetFloat(ValueMusic, valueMusic);
        }
        public static void SaveValueEffect(float valueEffect)
        {
            PlayerPrefs.SetFloat(ValueEffect, valueEffect);
        }

        public static float LoadMusicValue()
        {
            return PlayerPrefs.GetFloat(ValueMusic);
        }

        public static float LoadEffectValue()
        {
            return PlayerPrefs.GetFloat(ValueEffect);
        }
    }
}
