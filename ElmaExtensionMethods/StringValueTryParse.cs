using ElmaExtensionMethods.Models;

namespace ElmaExtensionMethods
{
    public static class StringValueTryParse
    {
        public static TryParseResult<int> IntTryParse(this string source)
        {
            var result = int.TryParse(source, out var value);
            
            return new TryParseResult<int>(value, result);
        }
        
        public static TryParseResult<long> LongTryParse(this string source)
        {
            var result = long.TryParse(source, out var value);
            
            return new TryParseResult<long>(value, result);
        }
        
        public static TryParseResult<float> FloatTryParse(this string source)
        {
            var result = float.TryParse(source, out var value);
            
            return new TryParseResult<float>(value, result);
        }
        
        public static TryParseResult<double> DoubleTryParse(this string source)
        {
            var result = double.TryParse(source, out var value);
            
            return new TryParseResult<double>(value, result);
        }
        
        public static TryParseResult<decimal> DecimalTryParse(this string source)
        {
            var result = decimal.TryParse(source, out var value);
            
            return new TryParseResult<decimal>(value, result);
        }
        
        public static TryParseResult<bool> BoolTryParse(this string source)
        {
            var result = bool.TryParse(source, out var value);
            
            return new TryParseResult<bool>(value, result);
        }
    }
}