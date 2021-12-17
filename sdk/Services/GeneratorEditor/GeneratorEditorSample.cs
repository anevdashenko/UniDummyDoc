using System;
using System.Collections.Generic;
using System.Text;
using Editor.Documentation.Models;

namespace Editor.Documentation.Services.GeneratorEditor
{
    public class GeneratorEditorSample : IGeneratorEditor
    {
        private const int NameSpawnCount = Int32.MaxValue;
        private const string FormatMenuName = "{0}_{1}";
        private const string FormatClassName = "GeneratorEditorSample_{0}";
        private readonly StringBuilder _pageBuffer = new StringBuilder();
        
        public string GenerateEditorPage(string name, DocumentationData documentationData)
        {
            _pageBuffer.Clear();
            AddHeader(name);

            var categoryContainers = GenerateCategoryContainers(documentationData.Categories);
            GeneratePageMenuItems(categoryContainers);
            CloseMenuItems();

            GenerateItemsClasses(categoryContainers);

            AddFooter();
            
            return _pageBuffer.ToString();
        }

        private void AddFooter()
        {
            _pageBuffer.Append(ConstantEditorPage.Footer);
        }

        private void AddHeader(string name)
        {
            var header = ConstantEditorPage.Header.Replace(ConstantEditorPage.KeyClassName, name);
            _pageBuffer.Append(header);
        }

        private List<CategoryContainer> GenerateCategoryContainers(List<DocumentationCategory> categories)
        {
            var containers = new List<CategoryContainer>();
            HashSet<string> usedNames = new HashSet<string>();
            
            foreach (var category in categories)
            {
                var menuName = GenerateMenuName(category.Name, usedNames);
                var className = GenerateClassName(menuName);
                var container = new CategoryContainer
                {
                    Category = category,
                    ClassName = className,
                    MenuName = menuName
                };
                
                containers.Add(container);
            }
            
            return containers;
        }

        private string GenerateMenuName(string categoryName, HashSet<string> usedNames)
        {
            if (!usedNames.Contains(categoryName))
            {
                usedNames.Add(categoryName);
                return categoryName;
            }

            for (int i = 0; i < NameSpawnCount; i++)
            {
                var name = string.Format(FormatMenuName, categoryName, i);
                if (!usedNames.Contains(name))
                {
                    usedNames.Add(name);
                    return name;
                }
            }

            var dummyName = string.Format(FormatMenuName, categoryName, usedNames.Count);
            usedNames.Add(dummyName);
            return dummyName;
        }
        
        private string GenerateClassName(string menuName)
        {
            return string.Format(FormatClassName, menuName);
        }
        
        private void GeneratePageMenuItems(List<CategoryContainer> categoryContainers)
        {
            foreach (var container in categoryContainers)
            {
                _pageBuffer.Append(string.Format(ConstantEditorPage.TemplateMenuItem, container.MenuName, container.ClassName));
            }
        }
        
        private void CloseMenuItems()
        {
            _pageBuffer.Append(ConstantEditorPage.MenuEnd);
        }
        
        private void GenerateItemsClasses(List<CategoryContainer> categoryContainers)
        {
            var contentClasses = new StringBuilder();
            foreach (var categoryContainer in categoryContainers)
            {
                FillClassContent(categoryContainer, contentClasses);
                var classContent = ConstantEditorPage.TemplateClassCategory.Replace(ConstantEditorPage.KeyClassName, categoryContainer.ClassName);
                classContent = classContent.Replace(ConstantEditorPage.KeyClassContent, contentClasses.ToString());
                _pageBuffer.Append(classContent);
            }
        }

        private void FillClassContent(CategoryContainer categoryContainer, StringBuilder contentClasses)
        {
            contentClasses.Clear();
            for (int i = 0; i < categoryContainer.Category.Items.Count; i++)
            {
                var item = categoryContainer.Category.Items[i];
                contentClasses.Append(string.Format(ConstantEditorPage.TemplateCategoryRecord, item.Name, item.Description, i));
            }
        }

        private class CategoryContainer
        {
            public DocumentationCategory Category;
            public string MenuName;
            public string ClassName;
        }
    }
}