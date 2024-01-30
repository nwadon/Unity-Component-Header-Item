using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace NoDawn.Inspector
{
    public class InspectorComponentHeaderItem
    {
        private static Dictionary<Type, MethodInfo> methodDict = new Dictionary<Type, MethodInfo>();

        [InitializeOnLoadMethod]
        private static void Init()
        {
            EditorApplication.update += InitHeader;
        }

        private static void InitHeader()
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Static;

            FieldInfo fieldInfo = typeof(EditorGUIUtility).GetField("s_EditorHeaderItemsMethods", flags);
            IList value = (IList)fieldInfo.GetValue(null);
            if (value == null) return;
            Type delegateType = value.GetType().GetGenericArguments()[0];

            Func<Rect, UnityEngine.Object[], bool> func = DrawHeaderItem;
            TypeCache.MethodCollection methods = TypeCache.GetMethodsWithAttribute<ComponentHeaderItemAttribute>();
            foreach (MethodInfo method in methods)
            {
                if (!method.IsStatic) return;
                if (methodDict.ContainsKey(method.ReflectedType)) return;
                methodDict.Add(method.ReflectedType, method);
                value.Add(Delegate.CreateDelegate(delegateType, func.Method));
            }

            EditorApplication.update -= InitHeader;
        }

        private static bool DrawHeaderItem(Rect rect, UnityEngine.Object[] targets)
        {
            UnityEngine.Object target = targets[0];

            Type targetType = target.GetType();
            
            if (methodDict.ContainsKey(targetType))
            {
                //object instance = Activator.CreateInstance(target.GetType());
                methodDict.TryGetValue(targetType, out MethodInfo method);
                ParameterInfo[] parameters = method.GetParameters();
                List<Type> parametersType = new List<Type>();
                
                foreach(var parameter in parameters)
                {
                    parametersType.Add(parameter.ParameterType);
                }

                Type rectType = rect.GetType();

                if (parametersType.Count == 1 && parametersType.Contains(rectType))
                {
                    method.Invoke(null, new object[] { rect });
                }
                else
                {
                    GUIStyle errorStyle = new GUIStyle();
                    errorStyle.normal.textColor = Color.red;
                    errorStyle.alignment = TextAnchor.MiddleCenter;
                    errorStyle.fontStyle = FontStyle.Bold;
                    errorStyle.fontSize = 12;
                    rect.width = 78;
                    rect.x -= 63;

                    string errorToolTip = "Method Parameter Error: Please make sure the parameter is correct";
                    GUI.Label(rect, new GUIContent(" Item Error!", EditorGUIUtility.IconContent("CollabError").image, errorToolTip), errorStyle);
                }
                return false;
            }
            return false;
        }
    }
}
