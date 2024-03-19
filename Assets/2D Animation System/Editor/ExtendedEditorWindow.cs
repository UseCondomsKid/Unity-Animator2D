//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;


//public class ExtendedEditorWindow : EditorWindow
//{
//    protected SerializedObject serializedObject;
//    protected SerializedProperty currentProperty;

//    private string selectedPropertyPath;
//    protected SerializedProperty selectedProperty;


//    private Vector2 sideBarScroll;

//    protected void DrawProperties(SerializedProperty prop, bool drawChildren)
//    {
//        string lastPropPath = string.Empty;
//        foreach(SerializedProperty p in prop)
//        {
//            if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
//            {
//                EditorGUILayout.BeginHorizontal();
//                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
//                EditorGUILayout.EndHorizontal();

//                if (p.isExpanded)
//                {
//                    EditorGUI.indentLevel++;
//                    DrawProperties(p, drawChildren);
//                    EditorGUI.indentLevel--;
//                }
//            }
//            else
//            {
//                if (!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath)) { continue; }
//                lastPropPath = p.propertyPath;
//                EditorGUILayout.PropertyField(p, drawChildren);
//            }
//        }
//    }

//    protected void DrawSidebar(SerializedProperty prop)
//    {
//        sideBarScroll = EditorGUILayout.BeginScrollView(sideBarScroll);

//        foreach (SerializedProperty p in prop)
//        {
//            if (GUILayout.Button(p.displayName))
//            {
//                selectedPropertyPath = p.propertyPath;
//            }
//        }

//        if (!string.IsNullOrEmpty(selectedPropertyPath))
//        {
//            selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
//        }

//        EditorGUILayout.EndScrollView();
//    }


//    protected void DrawField(string propName, bool relative)
//    {
//        if (relative && selectedProperty != null)
//        {
//            //Maybe needs to use current property in some cases
//            EditorGUILayout.PropertyField(selectedProperty.FindPropertyRelative(propName), true);
//        }
//        else if (serializedObject != null)
//        {
//            EditorGUILayout.PropertyField(serializedObject.FindProperty(propName), true);
//        }
//    }

//    protected void Apply()
//    {
//        serializedObject.ApplyModifiedProperties();
//    }
//}
