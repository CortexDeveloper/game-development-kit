using System;
using Newtonsoft.Json;
using UnityEngine;

namespace GDK.SaveLoadService
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<TData>(TData data) => 
            JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

        public TData Deserialize<TData>(string serializedData)
        {
            try
            {
                return JsonConvert.DeserializeObject<TData>(serializedData);
            }
            catch
            {
                Debug.LogError($"Cannot deserialize {typeof(TData)}.");
            }

            return default;
        }
    }
}