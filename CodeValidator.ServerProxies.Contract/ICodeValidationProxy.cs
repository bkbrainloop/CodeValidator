namespace CodeValidator.ServerProxies.Contract
{
    public interface ICodeValidationProxy
    {
        /// <summary>
        /// Validates the code and returns a <see cref="IBooleanResult"/> with
        /// Success set to true if the code was successful, otherwise false.
        /// If the operation is not supported by the server, ErrorCode is set
        /// to NotSupported.
        /// </summary>
        /// <param name="code">Code to validate.</param>
        IBooleanResult ValidateCode(string code);
    }
}
