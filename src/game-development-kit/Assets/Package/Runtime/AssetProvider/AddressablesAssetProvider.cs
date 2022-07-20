using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GDK.AssetProvider
{
    public class AddressablesAssetProvider : IAssetProvider
    {
        private List<string> _loadedPaths = new();
        public List<string> LoadedPaths => _loadedPaths.ToList();
        
        private Dictionary<string, AsyncOperationHandle> _cachedAssets { get; } = new();

        public void Initialize() => 
            Addressables.InitializeAsync();

        public T Load<T>(string path) where T : Object
        {
            if (_cachedAssets.TryGetValue(path, out AsyncOperationHandle cachedHandle))
                return cachedHandle.Result as T;

            AsyncOperationHandle handle = Addressables.LoadAssetAsync<T>(path);
            handle.Completed += _ =>
            {
                _cachedAssets[path] = handle;
                _loadedPaths.Add(path);
            };

            return handle.WaitForCompletion() as T;
        }

        public async UniTask<T> LoadAsync<T>(string path) where T : Object
        {
            if (_cachedAssets.TryGetValue(path, out AsyncOperationHandle cachedHandle))
                return cachedHandle.Result as T;
            
            AsyncOperationHandle<T> handle =  Addressables.LoadAssetAsync<T>(path);
            handle.Completed += _ =>
            {
                _cachedAssets[path] = handle;
                _loadedPaths.Add(path);
            };

            return await handle.Task.AsUniTask();
        }

        public void CleanAllCachedAssets() => 
            CleanCachedAssets(_cachedAssets.Keys.ToList());

        public void CleanCachedAssets(List<string> assetsKeys)
        {
            foreach (string key in assetsKeys)
            {
                if (_cachedAssets.TryGetValue(key, out AsyncOperationHandle handle))
                {
                    Addressables.Release(handle);
                 
                    _cachedAssets.Remove(key);
                    _loadedPaths.Remove(key);
                }
            }
        }
    }
}