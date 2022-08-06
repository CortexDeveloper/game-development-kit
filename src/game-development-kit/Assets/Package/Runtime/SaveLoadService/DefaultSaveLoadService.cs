using System.Data.SqlTypes;

namespace GDK.SaveLoadService
{
    public class DefaultSaveLoadService : ISaveLoadService<SaveKey>
    {
        public ISavesStorage SavesStorage { get; }
        public ISerializer Serializer { get; }

        public DefaultSaveLoadService(ISavesStorage savesStorage, ISerializer serializer)
        {
            SavesStorage = savesStorage;
            Serializer = serializer;
        }

        public void Save<TData>(SaveKey key, TData data)
        {
            string serializedData = Serializer.Serialize(data);
            SavesStorage.Save(key.Name, serializedData);
        }

        public TData Load<TData>(SaveKey key)
        {
            string serializedData = SavesStorage.Load(key.Name);

            return Serializer.Deserialize<TData>(serializedData);
        }

        public void Reset(SaveKey key)
        {
            SavesStorage.Reset(key.Name);
        }

        public void ResetAll()
        {
            SavesStorage.ResetAll();
        }
    }
}