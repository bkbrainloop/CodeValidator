namespace CodeValidator.ServerProxies.Contract
{
    public enum ServerErrorCode
    {
        None,
        NotSupported,
        // an error code which was added in the future (after implementing the business layer)
        InternalServerError
    }
}
