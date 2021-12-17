using System;
using System.Collections.Generic;
using Editor.Documentation.Attributes;
using Editor.Documentation.Models;
using Editor.Documentation.Services;

namespace Libs.DummyDoc.sdk.Services.DocumentationProvider
{
    public class DocumentationProviderAttribute : IDocumentationProvider
    {
        private readonly Dictionary<string, DocumentationCategory> _searchContext =
            new Dictionary<string, DocumentationCategory>();

        public DocumentationData FormAppDocumentation()
        {
            var context = FillContext();
            var documentationData = GenerateDocumentationData(context);

            _searchContext.Clear();

            return documentationData;
        }

        private DocumentationData GenerateDocumentationData(Dictionary<string, DocumentationCategory> context)
        {
            var documentation = new DocumentationData();
            documentation.Categories.AddRange(context.Values);
            
            return documentation;
        }

        private Dictionary<string, DocumentationCategory> FillContext()
        {
            var assemblies =  AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (var aType in assembly.GetTypes())
                {
                    foreach (var attribute in aType.GetCustomAttributes(false))
                    {
                        if (attribute is DocumentationAttribute docAttribute)
                        {
                            var nameClass = aType.Name;
                            var category = GetDocumentationCategory(docAttribute.CategoryName);
                            category.Items.Add(new DocumentationCategoryItem(nameClass, docAttribute.Comments));
                        }
                    }

                }
            }

            return _searchContext;
        }

        private DocumentationCategory GetDocumentationCategory(string name)
        {
            if (_searchContext.TryGetValue(name, out var category))
            {
                return category;
            }

            category = new DocumentationCategory(name);
            _searchContext[name] = category;
            return category;
        }
    }
}