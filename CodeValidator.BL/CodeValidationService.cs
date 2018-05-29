using System;
using CodeValidator.BL.Contract;
using CodeValidator.ServerProxies.Contract;

namespace CodeValidator.BL
{
    public class CodeValidationService : ICodeValidationService
    {
        private readonly ICodeValidationProxy _codeValidationProxy;

        public CodeValidationService(ICodeValidationProxy codeValidationProxy)
        {
            _codeValidationProxy = codeValidationProxy ?? throw new ArgumentNullException(nameof(codeValidationProxy));
        }

        /// <inheritdoc />
        public bool IsValidCode(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentException("Code is null or empty", nameof(code));

            IBooleanResult validationResult;

            try
            {
                validationResult = _codeValidationProxy.ValidateCode(code);
            }
            catch (Exception e)
            {
                throw new Exception($"Unexpected error while validating code: {e}");
            }

            if (validationResult.Success)
            {
                return true;
            }

            if (!validationResult.Success)
            {
                if (validationResult.ErrorCode == ServerErrorCode.NotSupported)
                {
                    throw new CodeValidationNotSupportedException();
                }

                if (validationResult.ErrorCode != ServerErrorCode.None)
                {
                    throw new Exception($"Server returned an unknown error code: {validationResult.ErrorCode.ToString()}");
                }
            }

            return false;
        }
    }
}
