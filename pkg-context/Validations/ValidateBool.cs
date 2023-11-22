namespace pkg_context.Validations;

public static class ValidateBool
{
    public static void Validate(bool? value, string message)
    {
        if (value is null) throw new ArgumentException(message);
    }
}
