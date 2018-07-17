namespace ID
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger<T>();
    }
}