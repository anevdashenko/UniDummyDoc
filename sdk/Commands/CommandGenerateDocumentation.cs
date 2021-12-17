using System.IO;
using System.Text;
using Editor.Documentation.Services;
using Editor.Documentation.Services.FileHandler;
using Editor.Documentation.Services.GeneratorEditor;
using UnityEditor;

namespace Editor.Documentation.Commands
{
    public class CommandGenerateDocumentation
    {
        private readonly IDocumentationProvider _documentationProvider;
        private readonly IGeneratorEditor _generatorEditor;
        private readonly IFileHandler _fileHandler;

        public CommandGenerateDocumentation(IDocumentationProvider documentationProvider, IGeneratorEditor generatorEditor, IFileHandler fileHandler)
        {
            _documentationProvider = documentationProvider;
            _generatorEditor = generatorEditor;
            _fileHandler = fileHandler;
        }

        public void Execute(string generatePath)
        {
            var docName = GetEditorName(generatePath);
            
            var documentationData = _documentationProvider.FormAppDocumentation();
            var pageText = _generatorEditor.GenerateEditorPage(docName, documentationData);
            _fileHandler.SavePath(generatePath, pageText);
            AssetDatabase.ImportAsset(generatePath);
        }

        private string GetEditorName(string generatePath)
        {
            return Path.GetFileNameWithoutExtension(generatePath);
        }

    }
}