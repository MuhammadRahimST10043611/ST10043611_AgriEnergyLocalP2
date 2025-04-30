using System.Text.RegularExpressions;

namespace ProgAgriP2New.Services
{
    public interface IPasswordValidationService
    {
        bool IsValidPassword(string password, out string errorMessage);
    }

    public class PasswordValidationService : IPasswordValidationService
    {
        public bool IsValidPassword(string password, out string errorMessage)
        {
            // Check if password is null or empty
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            // Check if password contains at least 6 characters
            if (password.Length < 6)
            {
                errorMessage = "Password must be at least 6 characters long.";
                return false;
            }

            // Check if password contains at least one number
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                errorMessage = "Password must contain at least one number.";
                return false;
            }

            // Check if password contains at least one special character
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                errorMessage = "Password must contain at least one special character.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}