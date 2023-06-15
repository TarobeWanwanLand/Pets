using System.Collections.Generic;
using System.IO;
using System.Text;
using Pets.Editor.CodeBuilders;
using UnityEditor;

namespace Pets.Editor.NamingConstants
{
    public static class SceneEnumGenerator
    {
        private const string MenuItemName = "Pets/Create/Scene Naming Constants";
        private const string DefaultNamespace = "Pets.Core.Generated.Defines";
        private const string DefaultEnumName = "BuildScene";
        private const string DefaultScriptFolder = "Assets/Scripts/Runtime/Core/Generated/Defines/";
        private const string DefaultScriptName = "BuildScene.cs";
        
        [MenuItem(MenuItemName)]
        public static void Create()
        {
            //Logger.LogDebug("シーンの定数スクリプトを生成します");
            
            var codeString = GenerateCodeString();
            
            AssetsPathHelper.CreateFolderRecursive(DefaultScriptFolder);
            
            var absolutePath = AssetsPathHelper.ToAbsolutePath(DefaultScriptFolder + DefaultScriptName);
            File.WriteAllText(absolutePath, codeString, Encoding.UTF8);
            
            AssetDatabase.Refresh();
            
            //Logger.LogDebug("シーンの定数スクリプトの生成が完了しました");
        }
        
        private static string GenerateCodeString()
        {
            var builder = new CodeBuilder();
            
            using (builder.CreateNamespaceScope(DefaultNamespace))
            {
                using (var enumBuilder = builder.CreateEnumScope(AccessModifier.Public, DefaultEnumName))
                {
                    enumBuilder.AppendField("Invalid", -1);

                    foreach (var buildScene in GetBuildScenes())
                    {
                        enumBuilder.AppendField(buildScene.Name, buildScene.Index);
                    }
                }
            }

            return builder.ToString();
        }
        
        private static IEnumerable<(string Name, int Index)> GetBuildScenes()
        {
            var sceneCount = EditorBuildSettings.scenes.Length;
            for (var i = 0; i < sceneCount; i++)
            {
                var buildScene = EditorBuildSettings.scenes[i];
                if (!buildScene.enabled) 
                    continue;

                var path = buildScene.path;
                
                // シーンパスからシーン名だけを抜き出す
                // 文字列の長さを6だけ短くしているのは".unity"の部分を省くため
                var startIndex = path.LastIndexOf('/') + 1;
                var length = path.Length - startIndex - 6;
                var name = buildScene.path.Substring(startIndex, length);
                
                yield return (name, i);
            }
        } 
    }
}