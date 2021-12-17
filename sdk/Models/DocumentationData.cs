using System.Collections.Generic;

namespace Editor.Documentation.Models
{
    public class DocumentationData
    {
        public List<DocumentationCategory> Categories = new List<DocumentationCategory>();
    }

    public class DocumentationCategory
    {
        public string Name;

        public List<DocumentationCategoryItem> Items = new List<DocumentationCategoryItem>();

        public DocumentationCategory(string name)
        {
            Name = name;
        }
    }

    public class DocumentationCategoryItem
    {
        public string Name;
        public string Description;

        public DocumentationCategoryItem(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}