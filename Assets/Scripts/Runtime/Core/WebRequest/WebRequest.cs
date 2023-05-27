using Cysharp.Threading.Tasks;
using System.Net;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Pets.Core
{
    /// <summary>
    /// ウェブリクエストの送信を行う
    /// </summary>
    public static class WebRequest
    {
        /// <summary>
        /// ウェブリクエストのGETメソッドを送信し、レスポンスを受け取る
        /// </summary>
        /// <param name="url">送信先のURL</param>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>レスポンスのバイナリ</returns>
        /// <exception cref="UnityWebRequestException">ウェブリクエストが失敗した場合</exception>
        public static async UniTask<byte[]> GetAsync(string url, IProgress<float> progress = null, 
            CancellationToken cancellationToken = default)
        {
            using var webRequest = UnityWebRequest.Get(url);
            return await WaitWebRequestResponseAsync(webRequest, progress, cancellationToken);
        }
        
        /// <summary>
        /// ウェブリクエストのPOSTメソッドを送信し、レスポンスを受け取る
        /// </summary>
        /// <param name="url">送信先のURL</param>
        /// <param name="form">送信するフォーム</param>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>レスポンスのバイナリ</returns>
        /// <exception cref="UnityWebRequestException">ウェブリクエストが失敗した場合</exception>
        public static async UniTask<byte[]> PostAsync(string url, WWWForm form = null, IProgress<float> progress = null, 
            CancellationToken cancellationToken = default)
        {
            using var webRequest = UnityWebRequest.Post(url, form);
            return await WaitWebRequestResponseAsync(webRequest, progress, cancellationToken);
        }

        private static async UniTask<byte[]> WaitWebRequestResponseAsync(UnityWebRequest request, IProgress<float> progress, 
            CancellationToken cancellationToken)
        {
            await request.SendWebRequest().ToUniTask(progress, cancellationToken: cancellationToken);
            return request.downloadHandler.data;
        }
    }
}
