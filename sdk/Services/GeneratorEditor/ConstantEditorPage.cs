namespace Editor.Documentation.Services.GeneratorEditor
{
    public static class ConstantEditorPage
    {
        public static string Header => @"
using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Linq;
using UnityEngine;
using Sirenix.Utilities.Editor;
using Sirenix.Serialization;
using UnityEditor;
using Sirenix.Utilities;

#if UNITY_EDITOR
namespace DocEditor
{
    public class {{class_name}} : OdinMenuEditorWindow
    {

        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree();
";


        public static string KeyClassName => "{{class_name}}";
        public static string TemplateMenuItem => "tree.Add(\"{0}\", new {1}());\n";
        public static string MenuEnd => @"
            return tree;
        }

";

        public static string TemplateClassCategory => @"
        [Serializable]
        public class {{class_name}}
        {
            {{key_class_content}}
        }

";

        public static string TemplateCategoryRecord => @"
        [BoxGroup(""{0}"")] 
        [MultiLineProperty(3)]
        [ReadOnly]
        [HideLabel]
        public string Comments{2} = ""{1}"";
";

        public static string Footer => @"
    }
}
#endif
";

        public static string KeyClassContent => "{{key_class_content}}";
    }
    
}