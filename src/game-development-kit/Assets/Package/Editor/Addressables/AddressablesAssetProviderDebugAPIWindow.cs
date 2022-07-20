using System.Collections.Generic;
using GDK.AssetProvider;
using UnityEditor;
using UnityEngine;

namespace GDK.Editor.Package.Editor.Addressables
{
    public class AddressablesAssetProviderDebugAPIWindow : EditorWindow
    {
        public List<string> AssetsToLoad = new();
        public List<string> AssetsToUnload = new();

        private AddressablesAssetProvider _assetProvider = new();
        
        private SerializedObject so;
        
        [MenuItem("Tools/Addressables Debug API")]
        static void Init()
        {
            AddressablesAssetProviderDebugAPIWindow window = 
                (AddressablesAssetProviderDebugAPIWindow)GetWindow(typeof(AddressablesAssetProviderDebugAPIWindow));
            
            window.Show();
        }
        
        private void OnEnable()
        {
            ScriptableObject target = this;
            so = new SerializedObject(target);
        }

        void OnGUI()
        {
            so.Update();
            
            SerializedProperty assetsToLoadProperty = so.FindProperty(nameof(AssetsToLoad));
            EditorGUILayout.PropertyField(assetsToLoadProperty, true);
            
            SerializedProperty assetsToUnloadProperty = so.FindProperty(nameof(AssetsToUnload));
            EditorGUILayout.PropertyField(assetsToUnloadProperty, true);
            
            so.ApplyModifiedProperties();
            
            if (GUILayout.Button("Load Assets"))
            {
                foreach (string path in AssetsToLoad)
                {
                    _assetProvider.Load<Object>(path);
                }
            }
            
            if (GUILayout.Button("Unload Assets"))
            {
                _assetProvider.CleanCachedAssets(AssetsToUnload);
            }

            GUILayout.Label($"Cached Assets: \n { string.Join("\n", _assetProvider.LoadedPaths)}");
        }
    }
}