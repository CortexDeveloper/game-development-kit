using System;
using UnityEngine;

namespace GDK.SaveLoadService
{
    public class PlayerPrefsStorage : ISavesStorage
    {
        public void Save(string key, string serializedData)
        {
            PlayerPrefs.SetString(key, serializedData);
            PlayerPrefs.Save();
        }

        public string Load(string key) => 
            PlayerPrefs.GetString(key, String.Empty);

        public void Reset(string key) => 
            PlayerPrefs.DeleteKey(key);

        public void ResetAll() => 
            PlayerPrefs.DeleteAll();
    }
}