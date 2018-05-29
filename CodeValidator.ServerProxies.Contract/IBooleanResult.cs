namespace CodeValidator.ServerProxies.Contract
{
    public interface IBooleanResult
    {
        bool Success { get; }
        ServerErrorCode ErrorCode { get; }
    }
}
