using UnityEditor;
using UnityEngine;

namespace NoDawn.Inspector
{
    public class Component : MonoBehaviour
    {
        [ComponentHeaderItem]
        private static void DrawHeaderItem(Rect rect)
        {
            GUIStyle iconStyle = new GUIStyle(GUI.skin.GetStyle("IconButton"));
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.normal.textColor = Color.yellow;
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Plugins/NoDawn/Inspector/Example/Icon/icon_01.png");

            if (GUI.Button(rect, new GUIContent("", icon, "It's a custom button"), iconStyle))
            {

            }
            rect.x -= 110;
            rect.width = 110;
            GUI.Label(rect, new GUIContent("Custom Button =>", "It's a custom label"), labelStyle);
        }
    }
}
