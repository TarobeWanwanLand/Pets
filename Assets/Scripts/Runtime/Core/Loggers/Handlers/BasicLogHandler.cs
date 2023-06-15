using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pets.Core.Loggers.Handlers
{
    /// <summary>
    /// 汎用ログハンドラ
    /// </summary>
    public class BasicLogHandler : ILogHandler
    {
        public virtual void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            Debug.unityLogger.LogFormat(logType, context, format, args);
        }
        
        public virtual void LogException(Exception exception, Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }
    }
}