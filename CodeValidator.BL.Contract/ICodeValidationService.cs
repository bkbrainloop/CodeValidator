using System;

namespace CodeValidator.BL.Contract
{
    /// <summary>
    /// A service used for validating codes entered by the user.
    /// </summary>
    public interface ICodeValidationService
    {
        /// <summary>
        /// Validates the code and returns true if the code was valid
        /// or false if the vode was invalid.
        /// </summary>
        /// <param name="code">Code to authenticate.</param>
        /// <exception cref="ArgumentException">
        /// When the code is null or empty.
        /// </exception>
        /// <exception cref="CodeValidationNotSupportedException">
        /// If the server does not support code validation.
        /// </exception>
        /// <exception cref="Exception">
        /// When an unknown exception occurrs.
        /// The exception contains a user-friendly error message.
        /// </exception>
        bool IsValidCode(string code);
    }
}
