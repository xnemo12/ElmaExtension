using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace ElmaLogger
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class ExceptionLogger
    {
        private readonly object _context;

        private readonly string _methodName;
        public string Error { get; set; }
        
        public Action<string> ActionWriteError;

        public ExceptionLogger(string methodName = null, object context = null)
        {
            _methodName = methodName != null ? methodName + " - " : "";
            _context = context;
            ActionWriteError = WriteError;
        }

        public void WriteError(Exception error)
        {
            WriteError(error.ToString());
        }
        public void WriteError(string error)
        {
            var message = _methodName + error + "\r\n\r\n";
            if (_context == null)
                Error += message;
            else
            {
                var propertyList = _context.GetType().GetProperties();

                var property = propertyList.FirstOrDefault(x =>
                    Regex.Match(x.Name, "Debug|Debuglogs|Error|Errors", RegexOptions.IgnoreCase).Success);

                if (property == null)
                {
                    Error += message;
                    return;
                }

                var propertyValue = property.GetValue(_context, new object[] { });

                if (!string.IsNullOrEmpty(propertyValue as string))
                    property.SetValue(_context, propertyValue + message, new object[] { });
                else
                    property.SetValue(_context, message, new object[] { });
            }
        }

        public T NoEx<T>(Func<T> function, string memberName = null, Action<Exception> error = null)
        {
            try
            {
                var result = function.Invoke();
                if (result == null)
                    WriteError($"Property null {memberName}");
                return result;
            }
            catch (Exception e)
            {
                WriteError(memberName != null ? $"Property Name - {memberName} : Exception - {e}" : e.ToString());
                
                error?.Invoke(e);
            }

            return default;
        }
        public void NoEx(Action function, string actionName = null, Action<Exception> error = null)
        {
            try
            {
                function.Invoke();
            }
            catch (Exception e)
            {
                WriteError(actionName != null ? $"Property Name - {actionName} : Exception - {e}" : e.ToString());
                
                error?.Invoke(e);
            }
        }
        public T DefaultNoEx<T>(Func<T> function, T defaultValue, string memberName = null, Action<Exception> error = null)
        {
            var result = NoEx(function, memberName, error);
            
            return IsDefault(result) ? defaultValue : result;
        }
        public T NoNull<T>(T? data, string propertyName) where T : struct
        {
            if (data.HasValue)
            {
                return data.Value;
            }

            WriteError("Property null - " + propertyName);
            return default;
        }
        
        private static bool IsDefault<T>(T data)
        {
            if (data == null)
                return true;
            
            var type = data.GetType();

            if (type == typeof(string))
            {
                return string.IsNullOrEmpty(data as string);
            }
            
            if (type.IsValueType)
            {
                return data.GetHashCode() == default(T)?.GetHashCode();
            }

            return false;
        }
    }
}