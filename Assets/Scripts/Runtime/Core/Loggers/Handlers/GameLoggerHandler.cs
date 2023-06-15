using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pets.Core.Loggers.Handlers
{
    public class GameLoggerHandler : BasicLogHandler
    {
        private const string Prefix = "<color=green>[Game]</color> ";
        
        public override void LogFormat(LogType logType, Object context, string format, params object[] args)
        {
            base.LogFormat(logType, context, Prefix + format, args);
        }

        public override void LogException(Exception exception, Object context)
        {
            base.LogFormat(LogType.Exception, context, Prefix + exception.Message);
        }
    }
}