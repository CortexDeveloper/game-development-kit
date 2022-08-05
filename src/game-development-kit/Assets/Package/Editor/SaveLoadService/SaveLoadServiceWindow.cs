using GDK.SaveLoadService;
using UnityEditor;
using UnityEngine;

namespace GDK.Editor.Package.Editor.SaveLoadService
{
    public class SaveLoadServiceWindow : EditorWindow
    {
        private ISaveLoadService<SaveKey> _saveLoadService;

        private string _resetKey;
        
        [MenuItem("Tools/Save Load Service")]
        static void Init()
        {
            SaveLoadServiceWindow window = GetWindow<SaveLoadServiceWindow>(typeof(SaveLoadServiceWindow));
            
            window.Show();
        }

        private void OnEnable()
        {
            _saveLoadService = new DefaultSaveLoadService(new PlayerPrefsStorage(), );
        }

        private void OnGUI()
        {
            _resetKey = EditorGUILayout.TextField(_resetKey);
            
            if (GUILayout.Button("Reset")) 
                _saveLoadService.Reset(new SaveKey(_resetKey));

            if (GUILayout.Button("ResetAll")) 
                _saveLoadService.ResetAll();
        }
    }
}