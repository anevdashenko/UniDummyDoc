using Editor.Documentation.Commands;
using Editor.Documentation.Services.FileHandler;
using Editor.Documentation.Services.GeneratorEditor;
using Libs.DummyDoc.sdk.Services.DocumentationProvider;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Libs.DummyDoc.Editor
{
    public class EditorWindowGenerateDoc : OdinEditorWindow
    {
        private const string DefaultGeneratePath = "DocumentationEditor.cs";
        private const string KeyGeneratePath = "_pathGeneratePath";
        
        [ShowInInspector]
        [Sirenix.OdinInspector.FilePath]
        public string PathGenerate
        {
            get => EditorPrefs.GetString(KeyGeneratePath, DefaultGeneratePath);
            set => EditorPrefs.SetString(KeyGeneratePath, value);
        }

        [Button]
        private void GenerateDoc()
        {
            //TODO move to view model, think about it
            var documentationProvider = new DocumentationProviderAttribute();
            var generatorEditor = new GeneratorEditorSample();
            var fileHandler = new FileHandlerSample();
            var command = new CommandGenerateDocumentation(documentationProvider, generatorEditor, fileHandler);
            command.Execute(PathGenerate);
        }
        
    }
}