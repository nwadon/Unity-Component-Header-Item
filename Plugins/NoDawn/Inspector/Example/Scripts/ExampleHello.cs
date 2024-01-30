using UnityEditor;
using UnityEngine;

namespace NoDawn.Inspector
{
#if UNITY_EDITOR
    public enum LanguageType
    {
        English,
        Chinese,
        French,
        German,
        Japanese,
        Portuguese,
        Russian,
        Spanish,
    }
#endif

    public class ExampleHello : MonoBehaviour
    {
        public int Hello;
        public string Name;
        public int Age;

#if UNITY_EDITOR
        public static LanguageType languageType;
        [ComponentHeaderItem]
        private static void DrawHeaderItems(Rect rect)
        {
            // Icon Button Style
            GUIStyle iconStyle = new GUIStyle(GUI.skin.GetStyle("IconButton"));

            //Using Unity's built-in Icon requires adjusting the location of each Icon
            iconStyle.contentOffset = new Vector2(2.5f, 1.5f);
            //Draw Button
            if (GUI.Button(rect, new GUIContent("", EditorGUIUtility.IconContent("Clipboard").image, "Displays a list of languages"), iconStyle))
            {
                //TODO
                ShowContextMenu(rect);
            }

            //Adjust the Rect to avoid overlap between the two buttons
            rect.x -= 19;

            //Using Unity's built-in Icon requires adjusting the location of each Icon
            iconStyle.contentOffset = new Vector2(2f, 2f);
            //Draw Button
            if (GUI.Button(rect, new GUIContent("", EditorGUIUtility.IconContent("RectTransformRaw").image, "Switch a language at random"), iconStyle))
            {
                //TODO
                RandomButton();
            }
        }

        /// <summary>
        /// Random Language
        /// </summary>
        private static void RandomButton()
        {
            var random = UnityEngine.Random.Range(0,7);
            languageType = (LanguageType)random;
        }

        /// <summary>
        /// Show Context Menu
        /// </summary>
        /// <param name="rect"></param>
        private static void ShowContextMenu(Rect rect)
        {
            // Create Context Menu
            GenericMenu menu = new GenericMenu();
            // Add Item
            menu.AddItem(new GUIContent("Chinese"), false, ContextMenuSelect, 0);
            menu.AddItem(new GUIContent("English"), false, ContextMenuSelect, 1);
            menu.AddItem(new GUIContent("French"), false, ContextMenuSelect, 2);
            menu.AddItem(new GUIContent("German"), false, ContextMenuSelect, 3);
            menu.AddItem(new GUIContent("Japanese"), false, ContextMenuSelect, 4);
            menu.AddItem(new GUIContent("Portuguese"), false, ContextMenuSelect, 5);
            menu.AddItem(new GUIContent("Russian"), false, ContextMenuSelect, 6); 
            menu.AddItem(new GUIContent("Spanish"), false, ContextMenuSelect, 7);
            // Show Context Menu
            menu.DropDown(rect);
        }

        private static void ContextMenuSelect(object value)
        {
            languageType = (LanguageType)value;
        }
    }
#endif
}
