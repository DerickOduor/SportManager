using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models.Utils
{
    public class AppUtility
    {
        public static string Encrypt(string textToEncrypt, string key = "!-gfyugu\\E\\jgjguk87878))_6786yb08\\SSM")
        {
            RijndaelManaged expr_05 = new RijndaelManaged();
            expr_05.Mode = CipherMode.CBC;
            expr_05.Padding = PaddingMode.PKCS7;
            expr_05.KeySize = 128;
            expr_05.BlockSize = 128;
            byte[] arg_3C_0 = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = arg_3C_0.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(arg_3C_0, keyBytes, len);
            expr_05.Key = keyBytes;
            expr_05.IV = keyBytes;
            ICryptoTransform arg_75_0 = expr_05.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(arg_75_0.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        public static string Decrypt(string textToDecrypt, string key = "!-gfyugu\\E\\jgjguk87878))_6786yb08\\SSM")
        {
            RijndaelManaged expr_05 = new RijndaelManaged();
            expr_05.Mode = CipherMode.CBC;
            expr_05.Padding = PaddingMode.PKCS7;
            expr_05.KeySize = 128;
            expr_05.BlockSize = 128;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] arg_43_0 = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = arg_43_0.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(arg_43_0, keyBytes, len);
            expr_05.Key = keyBytes;
            expr_05.IV = keyBytes;
            byte[] plainText = expr_05.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        public static string RandomString()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, new Random().Next(6, 6)).Select(x => input[rand.Next(0, input.Length)]).ToArray());
        }
    }
}
