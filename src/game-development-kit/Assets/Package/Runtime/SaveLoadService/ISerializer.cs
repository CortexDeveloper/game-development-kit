using System;
using Newtonsoft.Json;
using UnityEngine;

namespace GDK.SaveLoadService
{
    public interface ISerializer
    {
        string Serialize<TData>(TData data);
        
        TData Deserialize<TData>(string serializedData);
    }

    public class JsonSerializer : ISerializer
    {
        public string Serialize<TData>(TData data) => 
            JsonConvert.SerializeObject(data);

        public TData Deserialize<TData>(string serializedData)
        {
            try
            {
                return JsonConvert.DeserializeObject<TData>(serializedData);
            }
            catch (Exception e)
            {
                Debug.LogError($"Cannot deserialize {typeof(TData)}.");
            }

            return default;
        }
    }
}