using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pets.Core.Runtime.Core.Loggers.Handlers
{
    /// <summary>
    /// 汎用ログハンドラ
    /// </summary>
    public abstract class BasicLogHandler : ILogHandler
    {
        public void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(logType, context, format, args);
        }
        
        public void LogException(Exception exception, Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }
    }
}