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
            // SavesStorage.Save(key.na, serializedData);
        }

        public TData Load<TData>()
        {
            throw new System.NotImplementedException();
        }

        public void Reset(SaveKey key)
        {
            throw new System.NotImplementedException();
        }

        public void ResetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}