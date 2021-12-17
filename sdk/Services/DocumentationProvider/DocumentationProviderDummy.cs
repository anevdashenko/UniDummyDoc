using Editor.Documentation.Models;

namespace Editor.Documentation.Services.DocumentationProvider
{
    public class DocumentationProviderDummy : IDocumentationProvider
    {
        public DocumentationData FormAppDocumentation()
        {
            var docReport = new DocumentationData();

            var category = new DocumentationCategory("Ability");
            category.Items.Add(new DocumentationCategoryItem("SystemDamage", "Calculate damage"));
            docReport.Categories.Add(category);

            category = new DocumentationCategory("Field");
            category.Items.Add(new DocumentationCategoryItem("SystemCellPosition", "Place at cell"));
            docReport.Categories.Add(category);
            
            return docReport;
        }
    }
}