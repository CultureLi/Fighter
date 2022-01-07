using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;
using System.Linq;

namespace UIFrameWork
{
    [CustomEditor(typeof(UIAutoGeneratorEditor))]
    public class UIAutoGeneratorEditor : Editor
    {
        //使用以下后缀命名的ui自动导出
        static Dictionary<string, Type> suffixToCom = new Dictionary<string, Type>
            {
                {"GO",typeof(GameObject)},
                {"Txt",typeof(Text)},
                {"RImg",typeof(RawImage)},
                {"Img",typeof(Image)},               
                {"Btn",typeof(Button)},
                {"Toggle",typeof(Toggle)},
                {"Input",typeof(InputField)},
                {"Slider",typeof(Slider)},
                {"Scroll",typeof(ScrollRect)},
                {"Dropdown",typeof(Dropdown)}
            };


        static Type GetTypeBySuffix(string name)
        {
            foreach(var data in suffixToCom)
            {
                if(name.EndsWith(data.Key))
                {
                    return data.Value; 
                }
            }
            return null;
        }

        [MenuItem("Tools/Ugui/生成Controller和view")]

        private static void AutoGen()
        {
            var view = Selection.activeGameObject;
            if (view == null)
            {
                Debug.LogError("请选中View");
                return;
            }
            if (!view.name.EndsWith("View"))
            {
                Debug.LogError("View命名规范：xxxView");
                return;
            }
            if (view.GetComponent<UIExporter>() == null)
            {
                Debug.LogError("没有添加UIExporter组件");
                return;
            }

            AutoGenView(view);
            AutoGenViewController(view);
        }
        private static void AutoGenViewController(GameObject view)
        {      
            string filePath = Application.dataPath + "/Scripts/UI/Controller/" + view.name + "Controller.cs";

            if (Directory.Exists(filePath))
            {
                return;
            }
            string controllerTemplate = File.ReadAllText(Application.dataPath + "/Plugins/UITools/Editor/ControllerTemplate.txt");
            controllerTemplate = controllerTemplate.Replace("$VIEWNAME$", view.name);

            File.WriteAllText(filePath, controllerTemplate, new UTF8Encoding(false));
            AssetDatabase.Refresh();
        }

        private static void AutoGenView(GameObject view)
        {
            string filePath = Application.dataPath + "/Scripts/UI/View/" + view.name + ".cs";
            string viewTemplate = File.ReadAllText(Application.dataPath + "/Plugins/UITools/Editor/ViewTemplate.txt");
            var exporter = view.GetComponent<UIExporter>();

            var allUI = view.GetComponentsInChildren<Transform>(true);

            var newSet = new HashSet<Component>();
            //查找命名后缀符合规范的ui,和components中已有的合并
            foreach (var ui in allUI)
            {
                if(GetTypeBySuffix(ui.name) != null)
                {
                    newSet.Add(ui);
                }
            }

            foreach(var ui in exporter.components)
            {
                if(ui != null)
                {
                    newSet.Add(ui);
                }
            }

            exporter.components = newSet.ToList().ToArray();

            StringBuilder viewDeclare = new StringBuilder();
            StringBuilder viewDefinate = new StringBuilder();

            for(int index=0;index<exporter.components.Length; index++)
            {
                var ui = exporter.components[index];
                Type comType = GetTypeBySuffix(ui.name);
                if (comType is null)
                {
                    comType = typeof(GameObject);
                }

                if (comType == typeof(GameObject))
                {
                    viewDeclare.AppendFormat("\t\tpublic GameObject {0};\r\n", ui.name);
                    viewDefinate.AppendFormat("\t\t\t{0} = exporter.Get({1});\r\n", ui.name, index);
                }
                else
                {
                    viewDeclare.AppendFormat("\t\tpublic {0} {1};\r\n", comType, ui.name);
                    viewDefinate.AppendFormat("\t\t\t{0} = exporter.Get<{1}>({2});\r\n", ui.name, comType, index);
                }
            }


            viewTemplate =
                viewTemplate.Replace("$Tips$","/// <summary>\r\n///以下代码为自动生成，请勿编辑！！\r\n/// <summary>")
                .Replace("$VIEWNAME$", view.name)
                .Replace("$VIEWDECLARE$", viewDeclare.ToString())
                .Replace("$VIEWDEFINATE$", viewDefinate.ToString());

            File.WriteAllText(filePath, viewTemplate, new UTF8Encoding(false));
            AssetDatabase.Refresh();
        }

    }
}