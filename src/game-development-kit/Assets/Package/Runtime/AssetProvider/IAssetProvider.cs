using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace GDK.AssetProvider
{
    public interface IAssetProvider
    {
        List<string> LoadedPaths { get; }

        void Initialize();

        T Load<T>(string path) where T : Object;
        UniTask<T> LoadAsync<T>(string path) where T : Object;

        void CleanAllCachedAssets();
        void CleanCachedAssets(List<string> assetsKeys);
    }
}