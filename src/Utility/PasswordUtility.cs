using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.Utility;
public class PasswordUtility
{
    public static void HashPassword(string plainPassword, out string hashedPassword, byte[] pepper)
    {
        var algorithm = new HMACSHA256(pepper);
        var passToByte = Encoding.UTF8.GetBytes(plainPassword);

        hashedPassword = BitConverter.ToString(algorithm.ComputeHash(passToByte));
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword, byte[] pepper)
    {
        HashPassword(plainPassword, out string hashToCompare, pepper);
        return hashToCompare == hashedPassword;
    }
}
