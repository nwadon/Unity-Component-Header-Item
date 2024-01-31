using UnityEngine;
using UnityEditor;

namespace NoDawn.Inspector
{
    [CustomEditor(typeof(ExampleHello))]
    public class ExampleHelloEditor : Editor
    {
        private string labelName = "";
        private string labelAge = "";
        private string labelHello = "";

        public override void OnInspectorGUI()
        {
            ExampleHello es = (ExampleHello)target;

            GUILayout.Label("Current Language: " + ExampleHello.languageType);
            EditorGUILayout.Space();

            switch (ExampleHello.languageType)
            {
                case LanguageType.English:
                    SetLabel("Name", "Age", "Hello!");
                    break;
                case LanguageType.Chinese:
                    SetLabel("名字", "年龄", "你好!");
                    break;  
                case LanguageType.French:
                    SetLabel("Le nom", "Âge", "Bonjour!");
                    break;
                case LanguageType.German:
                    SetLabel("Name", "Alter", "Hallo!");
                    break;
                case LanguageType.Japanese:
                    SetLabel("の名前をあげる", "年齢", "こんにちは!");
                    break;
                case LanguageType.Portuguese:
                    SetLabel("Nome", "Idade", "Olá!");
                    break;
                case LanguageType.Russian:
                    SetLabel("Имя", "Возраст", "Здравствыйте!");
                    break;
                case LanguageType.Spanish:
                    SetLabel("Nombre", "Edad", "Hola!");
                    break;
            }
            
            es.Name = EditorGUILayout.TextField(labelName, es.Name);
            es.Age = EditorGUILayout.IntField(labelAge, es.Age);
            GUILayout.Label(labelHello);
        }

        private void SetLabel(string name, string age, string hello)
        {
            labelName = name;
            labelAge = age;
            labelHello = hello;
        }
    }
}
