namespace GDK.SaveLoadService
{
    public interface ISaveLoadService<TSaveKey>
    {
        ISavesStorage SavesStorage { get; }
        
        void Save<TData>(TSaveKey key, TData data);
        
        TData Load<TData>(TSaveKey key);
        
        void Reset(TSaveKey key);

        void ResetAll();
    }
}