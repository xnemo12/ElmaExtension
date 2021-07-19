using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ElmaLogger.Contract;
using ElmaLogger.Models;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable CollectionNeverUpdated.Global

namespace ElmaLogger
{
    public partial class ElmaLogger : IElmaLogger
    {
        public List<string> WriteProperties { get; }
        
        private object Context { get; }
        public List<string> LogsArray { get; }
        public string Logs => string.Join("\n\n", LogsArray);
        private string MethodName { get; set; } = "";

        public ElmaLogger()
        {
            LogsArray = new List<string>();
            WriteProperties = new List<string>
            {
                "Debug",
                "Debuglog",
                "Error",
                "Errors",
                "Logs",
                "Log"
            };
        }
        public ElmaLogger(string methodName) : this() => MethodName = methodName;
        public ElmaLogger(string methodName, object context) : this(methodName) => Context = context;

        public void WriteLog(
            string log, 
            LogLevel level = LogLevel.Informational, 
            string comment = "")
        {
            // if null exit method
            if(string.IsNullOrWhiteSpace(log))
                return;

            // if has comment
            if (comment != "")
                comment = $"({comment}) - ";

            // if has method name
            if (MethodName != "")
                MethodName = $"({MethodName}) - ";

            // create log value
            log = $"{DateTime.Now} - {level} - {MethodName}{comment}{log}";
            
            // write LogsArray properties
            if (Context == null)
            {
                LogsArray.Add(log);
            }
            // write Context property
            else
            {
                log += "\n\n";
                
                // Get Propertys
                var propertyList = Context.GetType().GetProperties();

                // Find Property
                var property = propertyList.FirstOrDefault(x =>
                    Regex.Match(x.Name, string.Join("|", WriteProperties), RegexOptions.IgnoreCase).Success);

                if (property == null)
                {
                    throw new Exception("Property not found in context");
                }
                
                // get property value
                var propertyValue = property.GetValue(Context, new object[] { });

                if (!string.IsNullOrEmpty(propertyValue as string))
                    property.SetValue(Context, propertyValue + log, new object[] { });
                else
                    property.SetValue(Context, log, new object[] { });
            }
        }
    }
}