using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Pets.Core.Http
{
    /// <summary>
    /// HTTPリクエストの送受信を行う
    /// </summary>
    public class WebRequest : IDisposable
    {
        private readonly UnityWebRequest _webRequest;
        
        /// <summary>
        /// レスポンスのバイナリ
        /// </summary>
        public ReadOnlySpan<byte> Response => _webRequest.downloadHandler.data;
        
        /// <summary>
        /// レスポンスの文字列
        /// </summary>
        public string ResponseText => _webRequest.downloadHandler.text;
        
        private WebRequest(UnityWebRequest webRequest) => _webRequest = webRequest;

        /// <summary>
        /// HTTP GET用のウェブリクエストを作成する
        /// </summary>
        /// <param name="uri">送信先のURI</param>
        public WebRequest CreateGetWebRequest(Uri uri)
        {
            var unityWebRequest = UnityWebRequest.Get(uri);
            return new WebRequest(unityWebRequest);
        }

        /// <summary>
        /// HTTP POST用のウェブリクエストを作成する
        /// </summary>
        /// <param name="uri">送信先のURI</param>
        /// <param name="form">送信するフォーム</param>
        public WebRequest CreatePostWebRequest(Uri uri, WWWForm form = null)
        {
            var unityWebRequest = UnityWebRequest.Post(uri, form);
            return new WebRequest(unityWebRequest);
        }

        /// <summary>
        /// 非同期でHTTPリクエストを送信してレスポンスを待ち受ける
        /// </summary>
        /// <param name="progress">進捗状況の通知を受け取るオブジェクト</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        private async UniTask SendAsync(IProgress<float> progress, CancellationToken cancellationToken)
        {
            await _webRequest.SendWebRequest().ToUniTask(progress, cancellationToken: cancellationToken);
        }

        public void Dispose() => _webRequest.Dispose();
    }

}
