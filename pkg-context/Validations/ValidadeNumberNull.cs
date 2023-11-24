namespace pkg_context.Validations;

public static class ValidadeNumberNull
{
    public static void Validate(int? number, string message)
    {
        if (number != null && number <= 0) throw new ArgumentException(message);
    }
}
