namespace pkg_context.Cryptography;

public static class CryptographyPassword
{
    public static string Hash(string password)
    {
        return HashPassword(password, 10);
    }

    public static bool VerifyPassword(string password, string hash)
    {
        return Verify(password, hash);
    }
}
