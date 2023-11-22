using System.Text.RegularExpressions;

namespace pkg_context.Validations;

public static class ValidateEmailAndLength
{
    public static void Validate(string email, int length, string messageError)
    {
        ValidateStringAndLength.Validate(email, length, messageError);

        if (!Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))) throw new ArgumentException(messageError);
    }
}
