using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using UnityEngine;

namespace Pets.Core.Runtime.Core.Loggers
{
    /// <summary>
    /// コア機能のロガー
    /// </summary>
    public static class Logger
    {
        private const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;
        
        private static readonly Dictionary<LogLevel, DisplayStyle> _displayStyles = new()
        {
            {LogLevel.Trace, new DisplayStyle("Trace: ", "#808080")},
            {LogLevel.Debug, new DisplayStyle("Debug: ", "#808080")},
            {LogLevel.Information, new DisplayStyle("Info: ", "#000000")},
            {LogLevel.Warning, new DisplayStyle("Warning: ", "#FFA500")},
            {LogLevel.Error, new DisplayStyle("Error: ", "#FF0000")},
            {LogLevel.Critical, new DisplayStyle("Critical: ", "#FF0000")},
            {LogLevel.None, new DisplayStyle("None: ", "#000000")}
        };

        [MethodImpl(Inline)]
        private static void LogImpl(LogLevel logLevel, string message)
        {
#if DEBUG
            var displayStyle = _displayStyles[logLevel];
            var colorCode = displayStyle.ColorCode;
            var prefix = displayStyle.Prefix;
            Debug.Log($"<color={colorCode}>{prefix}{message}</color>");
#endif
        }
        
        [MethodImpl(Inline)]
        public static void LogTrace(string message)
        {
            LogImpl(LogLevel.Trace, message);
        }
        
        [MethodImpl(Inline)]
        public static void LogDebug(string message)
        {
            LogImpl(LogLevel.Debug, message);
        }
        
        [MethodImpl(Inline)]
        public static void LogInfo(string message)
        {
            LogImpl(LogLevel.Information, message);
        }
        
        [MethodImpl(Inline)]
        public static void LogWarn(string message)
        {
            LogImpl(LogLevel.Warning, message);
        }
        
        [MethodImpl(Inline)]
        public static void LogError(string message)
        {
            LogImpl(LogLevel.Error, message);
        }
        
        [MethodImpl(Inline)]
        public static void LogCritical(string message)
        {
            LogImpl(LogLevel.Critical, message);
        }

        public struct DisplayStyle
        {
            public string Prefix { get; }
            public string ColorCode { get; }

            public DisplayStyle(string prefix, string colorCode)
            {
                Prefix = prefix;
                ColorCode = colorCode;
            }
        }
    }
}