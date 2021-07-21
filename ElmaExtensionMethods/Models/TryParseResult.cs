namespace ElmaExtensionMethods.Models
{
    public class TryParseResult<T> where T : struct
    {
        public TryParseResult(T? value, bool isSuccess)
        {
            Value = value;
            IsSuccess = isSuccess;
        }

        public T? Value { get; }
        public bool IsSuccess { get; }
    }
}