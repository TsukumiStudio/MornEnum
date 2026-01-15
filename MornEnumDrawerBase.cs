#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MornLib
{
    public abstract class MornEnumDrawerBase : PropertyDrawer
    {
        protected abstract string[] Values { get; }
        protected abstract Object PingTarget { get; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var keyProperty = property.FindPropertyRelative("_key");
            if (keyProperty == null || keyProperty.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            {
                var key = keyProperty.stringValue;
                var selectedIndex = Array.IndexOf(Values, key);
                
                if (Values.Length > 0)
                {
                    var dropdownRect = position;
                    var buttonRect = position;
                    
                    // PingTargetがある場合は、ドロップダウンの幅を調整してボタン用のスペースを作る
                    if (PingTarget != null)
                    {
                        var buttonWidth = 50f;
                        dropdownRect.width -= buttonWidth + 5f;
                        buttonRect.x = dropdownRect.xMax + 5f;
                        buttonRect.width = buttonWidth;
                    }
                    
                    if (selectedIndex < 0)
                    {
                        selectedIndex = 0;
                        keyProperty.stringValue = Values[selectedIndex];
                    }
                    else
                    {
                        selectedIndex = EditorGUI.Popup(dropdownRect, label.text, selectedIndex, Values);
                        keyProperty.stringValue = Values[selectedIndex];
                    }
                    
                    // PingTargetがある場合は「定義へ」ボタンを表示
                    if (PingTarget != null)
                    {
                        if (GUI.Button(buttonRect, "定義へ"))
                        {
                            EditorGUIUtility.PingObject(PingTarget);
                        }
                    }
                }
                else
                {
                    EditorGUI.LabelField(position, label.text, "No Values");
                    return;
                }   
            }
            EditorGUI.EndProperty();
            
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
        }
    }
}
#endif