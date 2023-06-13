using System;
using UnityEngine;

namespace Pets.Core.Runtime.Core.Loggers
{
    /// <summary>
    /// ロガーの基礎クラス
    /// </summary>
    public abstract class Logger
    {
        // ロガー本体
        private readonly ILogger _logger;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logHandler">ログハンドラ</param>
        protected Logger(ILogHandler logHandler)
        { 
            _logger = new UnityEngine.Logger(logHandler);
        }

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="message">メッセージ</param>
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("NEVER_DEFINED_SYMBOL_7259D988_3229_4E5B_8580_2600241935B1")]
#endif
        public void Log(string message)
        {
            _logger.LogFormat(LogType.Log, message);
        }
        
        /// <summary>
        /// 警告ログを出力する
        /// </summary>
        /// <param name="message">警告メッセージ</param>
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("NEVER_DEFINED_SYMBOL_7259D988_3229_4E5B_8580_2600241935B1")]
#endif
        public void LogWarning(string message)
        {
            _logger.LogFormat(LogType.Warning, message);
        }
        
        /// <summary>
        /// エラーログを出力する
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("NEVER_DEFINED_SYMBOL_7259D988_3229_4E5B_8580_2600241935B1")]
#endif
        public void LogError(string message)
        {
            _logger.LogFormat(LogType.Error, message);
        }
        
        /// <summary>
        /// 例外ログを出力する
        /// </summary>
        /// <param name="exception">例外</param>
#if !(UNITY_EDITOR || DEVELOPMENT_BUILD)
        [Conditional("NEVER_DEFINED_SYMBOL_7259D988_3229_4E5B_8580_2600241935B1")]
#endif
        public void LogException(Exception exception)
        {
            _logger.LogException(exception);
        }
    }
}