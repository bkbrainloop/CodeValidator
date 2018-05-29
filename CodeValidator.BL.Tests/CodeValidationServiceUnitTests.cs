using CodeValidator.ServerProxies.Contract;
using NUnit.Framework;

namespace CodeValidator.BL.Tests
{
    [TestFixture]
    public class CodeValidationServiceUnitTests
    {
        [Test]
        public void IsValidCode_WhenProxyReturnsSuccess_ReturnsTrue()
        {
            // Arrange
            var booleanResultMock = new BooleanResultMock();
            booleanResultMock.SetupSuccessReturnValue(true, ServerErrorCode.None);

            var codeValidationProxyMock = new CodeValidationProxyMock();
            codeValidationProxyMock.SetupValidateCodeReturnValue(booleanResultMock.MockedImplementation);

            var codeValidationService = new CodeValidationService(codeValidationProxyMock.MockedImplementation);

            var codeToTest = "666";

            // Act
            bool result = codeValidationService.IsValidCode(codeToTest);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidCode_WhenProxyReturnsSuccess_CalledProxyOnlyOnce()
        {
            // Arrange
            var booleanResultMock = new BooleanResultMock();
            booleanResultMock.SetupSuccessReturnValue(true, ServerErrorCode.None);

            var codeValidationProxyMock = new CodeValidationProxyMock();
            codeValidationProxyMock.SetupValidateCodeReturnValue(booleanResultMock.MockedImplementation);

            var codeValidationService = new CodeValidationService(codeValidationProxyMock.MockedImplementation);

            var codeToTest = "666";

            // Act
            codeValidationService.IsValidCode(codeToTest);

            // Assert
            Assert.AreEqual(1, codeValidationProxyMock.ValidateCodeNumberOfTimesCalled);
        }
    }
}
