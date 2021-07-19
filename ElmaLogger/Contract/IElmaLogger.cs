using System;
using System.Collections.Generic;
using ElmaLogger.Models;

namespace ElmaLogger.Contract
{
    public interface IElmaLogger
    {
        List<string> WriteProperties { get; }
        List<string> LogsArray { get; }
        string Logs { get; }

        void WriteLog(string log, LogLevel level = LogLevel.Informational, string comment = "");

        T NoEx<T>(Func<T> function, string comment = "", Action<Exception> error = null);
        void NoEx(Action function, string comment = "", Action<Exception> error = null);
        T DefaultIfNull<T>(Func<T> function, T defaultValue, string comment = "", Action<Exception> error = null);
        T NoNull<T>(T? data, string comment) where T : struct;
        void Emergency(string log, string comment = "");
        void Emergency(Exception log, string comment = "");
        void Alert(string log, string comment = "");
        void Alert(Exception log, string comment = "");
        void Critical(string log, string comment = "");
        void Critical(Exception log, string comment = "");
        void Error(string log, string comment = "");
        void Error(Exception log, string comment = "");
        void Warning(string log, string comment = "");
        void Warning(Exception log, string comment = "");
        void Notice(string log, string comment = "");
        void Notice(Exception log, string comment = "");
        void Informational(string log, string comment = "");
        void Informational(Exception log, string comment = "");
        void Debug(string log, string comment = "");
        void Debug(Exception log, string comment = "");
    }
}