using System;
using System.Collections.Concurrent;
using System.Threading;
using Cysharp.Threading.Tasks;
using Pets.Core.Helpers;

namespace Pets.Core.Runtime.Core.SceneStacks
{
    /// <summary>
    /// シーンのスタックを管理するクラス
    /// </summary>
    public class SceneStack
    {
        /// <summary>
        /// スレッドセーフなシーンのインデックスのスタック
        /// </summary>
        private readonly ConcurrentStack<int> _sceneIndexesStack = new();

        /// <summary>
        /// 非同期でシーンを読み込んでスタックに追加する
        /// </summary>
        /// <param name="sceneIndex">読み込むシーンのインデックス</param>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセル用トークン</param>
        public async UniTask PushAndLoadSceneAsync(int sceneIndex, IProgress<float> progress = null,
            CancellationToken cancellationToken = default)
        {
            // シーンを非同期で読み込む
            await SceneManagerHelper.LoadSceneAsync(sceneIndex, progress, cancellationToken);

            // スタックにシーンのインデックスを追加する
            _sceneIndexesStack.Push(sceneIndex);
        }

        /// <summary>
        /// 非同期でシーンをアンロードしてスタックから削除する
        /// </summary>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセル用トークン</param>
        public async UniTask PopAndUnloadSceneAsync(IProgress<float> progress = null, CancellationToken cancellationToken = default)
        {
            if (_sceneIndexesStack.Count == 0)
                throw new InvalidOperationException("スタック内にシーンが一つも読み込まれていません");
            
            // スタックからアンロードするシーンのインデックスを取り出す
            _sceneIndexesStack.TryPop(out var sceneToUnload);

            // シーンを非同期でアンロードする
            await SceneManagerHelper.UnloadSceneAsync(sceneToUnload, progress, cancellationToken);
        }
    }
}