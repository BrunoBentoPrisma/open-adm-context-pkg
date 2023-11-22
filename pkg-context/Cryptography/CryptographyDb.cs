namespace pkg_context.Cryptography;

public static class CryptographyDb
{
    private static readonly string key = "ea66738f-2273-4ac3-bc44-ded03b5c";
    private static readonly string iv = "8187600c-78c1-4c";
    public static byte[] EncryptByte(string plainText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var encrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(encrypt, encryptor, CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);

        swEncrypt.Write(plainText);
        swEncrypt.Close();
        csEncrypt.Close();

        return encrypt.ToArray();
    }

    public static string DecryptString(byte[] cipherText)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(key);
        aesAlg.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        using var msDecrypt = new MemoryStream(cipherText);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}
