namespace GDK.SaveLoadService
{
    public interface ISavesStorage
    {
        void Save(string key, string serializedData);
        
        string Load(string key);

        void Reset(string key);

        void ResetAll();
    }
}