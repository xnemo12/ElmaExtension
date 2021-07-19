using System;
using ElmaLogger.Models;

// ReSharper disable MemberCanBePrivate.Global

namespace ElmaLogger
{
    public partial class ElmaLogger
    {
        public void Emergency(string log, string comment = "")
            => WriteLog(log, LogLevel.Emergency, comment);

        public void Emergency(Exception log, string comment = "")
            => Emergency(log.ToString(), comment);

        public void Alert(string log, string comment = "")
            => WriteLog(log, LogLevel.Alert, comment);
        public void Alert(Exception log, string comment = "")
            => Alert(log.ToString(), comment);

        public void Critical(string log, string comment = "")
            => WriteLog(log, LogLevel.Critical, comment);
        public void Critical(Exception log, string comment = "")
            => Critical(log.ToString(), comment);

        public void Error(string log, string comment = "")
            => WriteLog(log, LogLevel.Error, comment);
        public void Error(Exception log, string comment = "")
            => Error(log.ToString(), comment);

        public void Warning(string log, string comment = "")
            => WriteLog(log, LogLevel.Warning, comment);
        public void Warning(Exception log, string comment = "")
            => Warning(log.ToString(), comment);

        public void Notice(string log, string comment = "")
            => WriteLog(log, LogLevel.Notice, comment);
        public void Notice(Exception log, string comment = "")
            => Notice(log.ToString(), comment);

        public void Informational(string log, string comment = "")
            => WriteLog(log, LogLevel.Informational, comment);
        public void Informational(Exception log, string comment = "")
            => Informational(log.ToString(), comment);

        public void Debug(string log, string comment = "")
            => WriteLog(log, LogLevel.Debug, comment);
        public void Debug(Exception log, string comment = "")
            => Debug(log.ToString(), comment);
    }
}