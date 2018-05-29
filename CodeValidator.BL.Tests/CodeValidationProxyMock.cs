using CodeValidator.ServerProxies.Contract;

namespace CodeValidator.BL.Tests
{
    public class CodeValidationProxyMock
    {
        private readonly MockedCodeValidationProxy _mockedImplementation = new MockedCodeValidationProxy();

        public ICodeValidationProxy MockedImplementation => _mockedImplementation;

        public int ValidateCodeNumberOfTimesCalled => _mockedImplementation.ValidateCodeNumberOfTimesCalled;

        public void SetupValidateCodeReturnValue(IBooleanResult returnValue)
        {
            _mockedImplementation.SetupValidateCode(returnValue);
        }

        private class MockedCodeValidationProxy : ICodeValidationProxy
        {
            private IBooleanResult _validateCodeReturnValue;

            public int ValidateCodeNumberOfTimesCalled { get; private set; }

            public IBooleanResult ValidateCode(string code)
            {
                return _validateCodeReturnValue;
            }

            public void SetupValidateCode(IBooleanResult returnValue)
            {
                _validateCodeReturnValue = returnValue;
                ValidateCodeNumberOfTimesCalled++;
            }
        }
    }
}
