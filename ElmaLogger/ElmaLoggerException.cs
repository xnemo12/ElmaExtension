using System;
// ReSharper disable MemberCanBePrivate.Global

namespace ElmaLogger
{
    public partial class ElmaLogger
    {
        public T NoEx<T>(Func<T> function, string comment = "", Action<Exception> error = null)
        {
            try
            {
                var result = function.Invoke();
                if (result == null)
                    Informational("Property is null", comment);
                return result;
            }
            catch (Exception e)
            {
                Error(e, comment);
                error?.Invoke(e);
            }

            return default;
        }
        
        public void NoEx(Action function, string comment = "", Action<Exception> error = null)
        {
            try
            {
                function.Invoke();
            }
            catch (Exception e)
            {
                Error(e, comment);
                error?.Invoke(e);
            }
        }
        
        public T DefaultIfNull<T>(Func<T> function, T defaultValue, string comment = "", Action<Exception> error = null)
        {
            var result = NoEx(function, comment, error);
            
            return IsDefault(result) ? defaultValue : result;
        }
        
        public T NoNull<T>(T? data, string comment) where T : struct
        {
            if (data.HasValue)
            {
                return data.Value;
            }

            Informational("Property is null", comment);
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