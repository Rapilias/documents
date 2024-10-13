using UnityEditor;
using UnityEngine;

namespace EgoParadise.Utility.Unity.Editor
{
    [InitializeOnLoad]
    public static class InspectorHeaderDrawer
    {
        static InspectorHeaderDrawer()
        {
            UnityEditor.Editor.finishedDefaultHeaderGUI -= InspectorHeaderDrawer.GUIDOnGUI;
            UnityEditor.Editor.finishedDefaultHeaderGUI += InspectorHeaderDrawer.GUIDOnGUI;
            UnityEditor.Editor.finishedDefaultHeaderGUI -= InspectorHeaderDrawer.AssetOnGUI;
            UnityEditor.Editor.finishedDefaultHeaderGUI += InspectorHeaderDrawer.AssetOnGUI;
        }
        
        private static void GUIDOnGUI(UnityEditor.Editor editor)
        {
            // ファイルとして存在していない
            if(EditorUtility.IsPersistent(editor.target) == false)
                return;
            var assetPath = AssetDatabase.GetAssetPath(editor.target);
            var guid = AssetDatabase.AssetPathToGUID(assetPath);
            var controlRect = EditorGUILayout.GetControlRect();
            var labelRect = EditorGUI.PrefixLabel(controlRect, new GUIContent("Guid"));
            if(editor.targets.Length == 1)
                EditorGUI.SelectableLabel(labelRect, guid);
        }
        
        private static void AssetOnGUI(UnityEditor.Editor editor)
        {
            // ファイルとして存在していない
            if(EditorUtility.IsPersistent(editor.target) == false)
                return;
            var controlRect = EditorGUILayout.GetControlRect();
            EditorGUI.BeginDisabledGroup(true);
            _ = EditorGUI.ObjectField(controlRect, new GUIContent("Asset"), editor.target, typeof(Object), false);
            EditorGUI.EndDisabledGroup();
        }
    }
}
