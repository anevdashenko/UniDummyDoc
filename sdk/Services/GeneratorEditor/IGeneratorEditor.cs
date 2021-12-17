using Editor.Documentation.Models;

namespace Editor.Documentation.Services.GeneratorEditor
{
    public interface IGeneratorEditor
    {
        string GenerateEditorPage(string name, DocumentationData documentationData);
    }
}