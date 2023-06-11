using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pets.Editor.CodeBuilders
{
    public class FileSystem
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
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            return assetsPath.Replace("Assets", Application.dataPath);
#else
            return assetsPath.Replace("Assets", Application.dataPath);
#endif
        }
        
        public static void CreateFolderRecursive(string path)
        {
            // Assetsから始まってない場合は処理できない
            if (!path.StartsWith("Assets/"))
                throw new System.ArgumentException("Assetsから始まるパスを指定してください", nameof(path));
 
            var directories = path.Split('/');
            var combinePath = directories[0];
            
            // Assets の部分はスキップ
            foreach (var dir in directories.Skip(1))
            {
                // ディレクトリの存在確認
                if (!AssetDatabase.IsValidFolder(combinePath + '/' + dir))
                    AssetDatabase.CreateFolder(combinePath, dir);
                combinePath += '/' + dir;
            }
        }
    }
}