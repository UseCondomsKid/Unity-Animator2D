//using System.Collections;
//using System.IO;
//using System.Linq;
//using Unity.EditorCoroutines.Editor;
//using UnityEditor;
//using UnityEngine;

//namespace UseCondomsKid.Animator2D
//{
//    public class SpriteAnimationEditorWindow : ExtendedEditorWindow
//    {
//        public static void Open(SpriteAnimationObject dataObject)
//        {
//            SpriteAnimationEditorWindow window = GetWindow<SpriteAnimationEditorWindow>("Sprite Animation Editor");
//            window.serializedObject = new SerializedObject(dataObject);
//        }

//        private void OnGUI()
//        {
//            currentProperty = serializedObject.FindProperty("SpriteAnimations");
//            DrawProperties(currentProperty, true);
//        }
//    }
//}
