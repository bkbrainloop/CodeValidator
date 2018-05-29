using CodeValidator.ServerProxies.Contract;

namespace CodeValidator.BL.Tests
{
    public class BooleanResultMock
    {
        private readonly DummyBooleanResult _dummyBooleanResult = new DummyBooleanResult();

        // access to mocked implementation
        public IBooleanResult MockedImplementation => _dummyBooleanResult;

        // methods for setting up mocked implementation
        public void SetupSuccessReturnValue(bool success, ServerErrorCode serverErrorCode)
        {
            _dummyBooleanResult.Success = success;
            _dummyBooleanResult.ErrorCode = serverErrorCode;
        }

        // nested mocked implementation
        private class DummyBooleanResult : IBooleanResult
        {
            public bool Success { get; set;  }
            public ServerErrorCode ErrorCode { get; set; }
        }
    }
}
