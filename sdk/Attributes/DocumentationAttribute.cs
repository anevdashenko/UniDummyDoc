using System;

namespace Editor.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.All)]
    public class DocumentationAttribute : Attribute
    {
        public string CategoryName { get; private set; }
        public string Comments { get; private set; }

        public DocumentationAttribute(string categoryName, string comments)
        {
            CategoryName = categoryName;
            Comments = comments;
        }
    }
}