namespace GDK.SaveLoadService
{
    public interface ISerializer
    {
        string Serialize<TData>(TData data);
        
        TData Deserialize<TData>(string serializedData);
    }
}