using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Core.Helpers;

public static class UrlShortenerHelper
{
    private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly int Base = Alphabet.Length;

    public static string GenerateShortKey(string longUrl)
    {
        const int shortKeyLength = 4;

        byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(longUrl));
        byte[] hashPrefix = hash[..shortKeyLength];

        if (BitConverter.IsLittleEndian) Array.Reverse(hashPrefix);

        int value = BitConverter.ToInt32(hashPrefix);

        return EncodeToBase62(value);
    }

    public static string EncodeToBase62(int value)
    {
        if (value < 0) value = ~value; // ensure positive if hash yields negative number

        if (value == 0)
            return Alphabet[0].ToString();

        var sb = new StringBuilder();
        while (value > 0)
        {
            sb.Insert(0, Alphabet[value % Base]);
            value /= Base;
        }

        return sb.ToString();
    }
}