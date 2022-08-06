using GDK.SaveLoadService;
using UnityEditor;
using UnityEngine;

namespace GDK.Editor.Package.Editor.SaveLoadService
{
    public class SaveLoadServiceWindow : EditorWindow
    {
        private ISaveLoadService<SaveKey> _saveLoadService;

        private string _saveKey;
        
        [MenuItem("Tools/Save Load Service")]
        static void Init()
        {
            SaveLoadServiceWindow window = GetWindow<SaveLoadServiceWindow>(typeof(SaveLoadServiceWindow));
            
            window.Show();
        }

        private void OnEnable()
        {
            _saveLoadService = new DefaultSaveLoadService(new PlayerPrefsStorage(), new JsonSerializer());
        }

        private void OnGUI()
        {
            _saveKey = EditorGUILayout.TextField(_saveKey);
            
            if (GUILayout.Button("Save Test Object")) 
                _saveLoadService.Save(new SaveKey(_saveKey), new TestData()
                {
                    Vector = new Vector2(123, 456),
                    String = "abcd",
                    Enum = TestData.MyEnum.One
                });

            if (GUILayout.Button("Load Test Object"))
            {
                TestData testData = _saveLoadService.Load<TestData>(new SaveKey(_saveKey));
                
                Debug.Log(testData.ToString());
            }

            if (GUILayout.Button("Reset")) 
                _saveLoadService.Reset(new SaveKey(_saveKey));

            if (GUILayout.Button("ResetAll")) 
                _saveLoadService.ResetAll();
        }
    }
}