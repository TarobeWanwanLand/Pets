using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Pets.Core.Helpers
{
    public static class SceneManagerHelper
    {
        /// <summary>
        /// 非同期で指定されたシーンをロードします
        /// </summary>
        /// <param name="sceneIndex">ロードするシーンのインデックス</param>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセル用トークン</param>
        public static async UniTask LoadSceneAsync(int sceneIndex, IProgress<float> progress = null,
            CancellationToken cancellationToken = default)
        {
            await SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive)
                .ToUniTask(progress, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// 非同期で指定されたシーンをアンロードします
        /// </summary>
        /// <param name="sceneIndex">アンロードするシーンのインデックス</param>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセル用トークン</param>
        public static async UniTask UnloadSceneAsync(int sceneIndex, IProgress<float> progress = null,
            CancellationToken cancellationToken = default)
        {
            await SceneManager.UnloadSceneAsync(sceneIndex)
                .ToUniTask(progress, cancellationToken: cancellationToken);
        }
    }
}