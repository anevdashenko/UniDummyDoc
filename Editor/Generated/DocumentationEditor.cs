
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
    public class DocumentationEditor : OdinMenuEditorWindow
    {

        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree();
tree.Add("Bootstrap", new GeneratorEditorSample_Bootstrap());
tree.Add("Controllers", new GeneratorEditorSample_Controllers());

            return tree;
        }


        [Serializable]
        public class GeneratorEditorSample_Bootstrap
        {
            
        [BoxGroup("InstallerProject")] 
        [MultiLineProperty(3)]
        [ReadOnly]
        [HideLabel]
        public string Comments0 = "Создает сервисы приложения и заполняет ими контекст который будет доступен в течении жизни всего приложения";

        [BoxGroup("InstallerFactory")] 
        [MultiLineProperty(3)]
        [ReadOnly]
        [HideLabel]
        public string Comments1 = "Installer zenject, installing abstract factories";

        [BoxGroup("InstallerReflexTest")] 
        [MultiLineProperty(3)]
        [ReadOnly]
        [HideLabel]
        public string Comments2 = "тестовый установщик сцены reflex";

        }


        [Serializable]
        public class GeneratorEditorSample_Controllers
        {
            
        [BoxGroup("ControllerCoroutineTest")] 
        [MultiLineProperty(3)]
        [ReadOnly]
        [HideLabel]
        public string Comments0 = "проводит тесты корутин юнити";

        }


    }
}
#endif
