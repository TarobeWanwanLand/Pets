using System;
using System.Diagnostics;   // Conditional属性に使用する
using UnityEngine;

namespace Pets.Core.Loggers
{
    /// <summary>
    /// ロガーの基礎クラス
    /// </summary>
    public class Logger
    {
        // ロガー本体
        private readonly ILogger _logger;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logHandler">ログハンドラ</param>
        public Logger(ILogHandler logHandler)
        { 
            _logger = new UnityEngine.Logger(logHandler);
        }

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="message">メッセージ</param>
        public void Log(string message)
        {
            _logger.LogFormat(LogType.Log, message);
        }

        /// <summary>
        /// デバッグログを出力する
        /// </summary>
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("NEVER_DEFINED_SYMBOL_7259D988_3229_4E5B_8580_2600241935B1")]
#endif
        public void DebugLog(string message)
        {
            _logger.Log(LogType.Log, message);
        }

        /// <summary>
        /// 警告ログを出力する
        /// </summary>
        /// <param name="message">警告メッセージ</param>
        public void LogWarning(string message)
        {
            _logger.LogFormat(LogType.Warning, message);
        }
        
        /// <summary>
        /// エラーログを出力する
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        public void LogError(string message)
        {
            _logger.LogFormat(LogType.Error, message);
        }
        
        /// <summary>
        /// 例外ログを出力する
        /// </summary>
        /// <param name="exception">例外</param>
        public void LogException(Exception exception)
        {
            _logger.LogException(exception);
        }
    }
}