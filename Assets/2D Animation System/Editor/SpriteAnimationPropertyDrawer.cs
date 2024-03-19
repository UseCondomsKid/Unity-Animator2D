//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UseCondomsKid.Animator2D;

//[CustomPropertyDrawer(typeof(SpriteAnimation))]
//public class SpriteAnimationPropertyDrawer : PropertyDrawer
//{
//    SerializedProperty nameProp;
//    SerializedProperty loopProp;
//    SerializedProperty framesProp;
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);

//        Rect nameRect = new Rect(position.x, position.y, position.width, 16f);
//        Rect loopRect = new Rect(position.x, position.y + 20f, position.width, 16f);
//        Rect framesRect = new Rect(position.x, position.y + 40f, position.width, 16f);

//        nameProp = property.FindPropertyRelative("Name");
//        loopProp = property.FindPropertyRelative("Loop");
//        framesProp = property.FindPropertyRelative("Frames");

//        EditorGUI.PropertyField(nameRect, nameProp, true);
//        EditorGUI.PropertyField(loopRect, loopProp, true);
//        EditorGUI.PropertyField(framesRect, framesProp, true);

//        EditorGUI.EndProperty();
//    }
//}
