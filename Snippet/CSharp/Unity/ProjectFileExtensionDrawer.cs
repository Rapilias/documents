using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace EgoParadise.Utility.Unity.Editor
{
    /// <summary>
    /// Project ビューでファイルの拡張子を表示する
    /// </summary>
    [InitializeOnLoad]
    public static class ProjectFileExtensionDrawer
    {
        static ProjectFileExtensionDrawer()
        {
            EditorApplication.projectWindowItemOnGUI -= Draw;
            EditorApplication.projectWindowItemOnGUI += Draw;
        }

        private static Dictionary<string, GUIContent> _guiCache = new Dictionary<string, GUIContent>();
        private static GUIStyle _oneColumnStyle;
        private static GUIStyle _twoColumnStyle;

        private static void Draw(string guid, Rect selectionrect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);

            if(string.IsNullOrWhiteSpace(path))
                return;
            var filename = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);
            if(string.IsNullOrWhiteSpace(extension))
                return;
            // リスト表示の時だけ通す
            if(selectionrect.height > 20)
                return;
            if(Directory.Exists(path))
                return;

            // Note: static constructor時点で取れないのでここで取得
            _oneColumnStyle ??= new GUIStyle(EditorStyles.label);
            _twoColumnStyle ??= new GUIStyle(EditorStyles.wordWrappedLabel);
            // 幅14以下のファイルなら2列表示と決め打つ
            var activeStyle = selectionrect.x <= 14 ? _twoColumnStyle : _oneColumnStyle;

            var extensionGui = GetOrCreateExtensionGui(extension);
            var extensionSize = activeStyle.CalcSize(extensionGui);
            var filenameWidth = activeStyle.CalcSize(new GUIContent(filename)).x;
            var drawPosition = selectionrect.position;
            // 描画済みの幅 + アイコンの幅
            drawPosition.x += filenameWidth + 14;
            var drawRect = new Rect(drawPosition, extensionSize);
            // TODO .png, .shadergraph 等一部で末尾の文字が消失するので調整
            drawRect.width += 8;
            GUI.Label(drawRect, extensionGui, activeStyle);
        }

        // キャッシュにあるGUIContentを探して無ければ作る
        private static GUIContent GetOrCreateExtensionGui(string extension)
        {
            _guiCache.TryGetValue(extension, out var gui);
            if(gui == null)
            {
                gui = new GUIContent(extension);
                _guiCache.Add(extension, gui);
            }
            return gui;
        }
    }
}
#endif
