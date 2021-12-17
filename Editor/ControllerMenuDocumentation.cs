using DocEditor;
using Libs.DummyDoc.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;

namespace Editor.Documentation
{
    public static class ControllerMenuDocumentation
    {
        [MenuItem("Doc/Documentation")]
        private static void OpenDocumentationWindow()
        {
            var window = EditorWindow.GetWindow<DocumentationEditor>();

            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
        }
        
        [MenuItem("Doc/Generate")]
        private static void OpenGenerateDocWindow()
        {
            var window = EditorWindow.GetWindow<EditorWindowGenerateDoc>();

            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(700, 700);
        }
        
        
    }
}