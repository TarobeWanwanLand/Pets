using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pets.Editor.CodeBuilders
{
    public class AssetsPathHelper
    {
        /// <summary>
        /// 絶対パスからアセットパスに変換する
        /// </summary>
        /// <param name="absolutePath">絶対パス</param>
        public static string FromAbsolutePath(string absolutePath)
        {
            return absolutePath.Replace(Application.dataPath, "Assets");
        }
        
        /// <summary>
        /// アセットパスから絶対パスに変換する
        /// </summary>
        /// <param name="assetsPath">アセットパス</param>
        public static string ToAbsolutePath(string assetsPath)
        {
            return assetsPath.Replace("Assets", Application.dataPath);
        }
        
        /// <summary>
        /// フォルダを再帰的に作成する
        /// </summary>
        /// <param name="assetsPath">Assetsから始まるパス</param>
        public static void CreateFolderRecursive(string assetsPath)
        {
            // Assetsから始まってない場合は処理できない
            if (!assetsPath.StartsWith("Assets/"))
                throw new System.ArgumentException("Assetsから始まるパスを指定してください", nameof(assetsPath));
 
            // 末尾の'/'を削除
            if (assetsPath.EndsWith("/"))
                assetsPath = assetsPath.Substring(0, assetsPath.Length - 1);
            
            // フォルダを作成する
            var absolutePath = ToAbsolutePath(assetsPath);
            System.IO.Directory.CreateDirectory(absolutePath);
        }
    }
}