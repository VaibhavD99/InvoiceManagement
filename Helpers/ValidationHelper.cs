
namespace InvoiceManagement.Helpers
{
    public static class ValidationHelper
    {
        public static bool ContainsSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var specialChars = "!@#$%^&*()_+[]{}|;:',.<>?/`~";
            return input.Any(ch => specialChars.Contains(ch));
        }

        public static bool IsPositiveNumber(decimal number)
        {
            return number > 0;
        }
    }
}
