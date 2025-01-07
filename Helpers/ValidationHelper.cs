
namespace InvoiceManagement.Helpers
{
    public static class ValidationHelper
    {
        // Check if a string contains special characters
        public static bool ContainsSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var specialChars = "!@#$%^&*()_+[]{}|;:',.<>?/`~";
            return input.Any(ch => specialChars.Contains(ch));
        }

        // Validate a numeric property
        public static bool IsPositiveNumber(decimal number)
        {
            return number > 0;
        }
    }
}
