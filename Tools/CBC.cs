using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace Tools
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:CBC Encryption and Decryption
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class CBC
    {
        public const string key = "qsy4w2mr35biedi04zf8foq1k0lhw181"; // 32-byte key
        public const string iv = "0102037405060701"; //16-byte IV

        /// <summary>
        /// Receive HtmlDecode and decrypt using Decrypt
        /// </summary>
        /// <param name="toDecrypt">String to be decrypted</param>
        /// <returns></returns>
        public static string DecryptHtmlDecode(string toDecrypt)
        {
            return Decrypt(WebUtility.HtmlDecode(toDecrypt).Replace(" ", "+"));
        }

        /// <summary>
        /// Receive a string and encrypt it using HtmlEncode
        /// </summary>
        /// <param name="toEncrypt">String to be encrypted</param>
        /// <returns></returns>
        public static string HtmlEncodeEncrypt(string toEncrypt)
        {
            return WebUtility.HtmlEncode(Encrypt(toEncrypt));
        }

        /// <summary>
        /// Receive UrlEncode and decrypt using Decrypt
        /// </summary>
        /// <param name="toDecrypt">String to be decrypted</param>
        /// <returns></returns>
        public static string DecryptUrlDecode(string toDecrypt)
        {
            return Decrypt(WebUtility.UrlDecode(toDecrypt).Replace(" ", "+"));
        }

        /// <summary>
        /// Receive a string and encrypt it
        /// </summary>
        /// <param name="toEncrypt">String to be encrypted</param>
        /// <returns></returns>
        public static string UrlEncodeEncrypt(string toEncrypt)
        {
            return WebUtility.UrlEncode(Encrypt(toEncrypt));
        }

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="toEncrypt">String to be encrypted</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] ivArray = Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            using (var aes = Aes.Create())
            {
                aes.Key = keyArray;
                aes.IV = ivArray;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] resultArray = encryptor.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return Convert.ToBase64String(resultArray);
                }
            }
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="toDecrypt">String to be decrypted</param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt)
        {
            try
            {
                byte[] keyArray = Encoding.UTF8.GetBytes(key);
                byte[] ivArray = Encoding.UTF8.GetBytes(iv);
                byte[] toDecryptArray = Convert.FromBase64String(toDecrypt);

                using (var aes = Aes.Create())
                {
                    aes.Key = keyArray;
                    aes.IV = ivArray;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor())
                    {
                        byte[] resultArray = decryptor.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                        return Encoding.UTF8.GetString(resultArray);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error (can be replaced with actual logging method)
                Console.WriteLine($"Decryption failed: {ex.Message}");
                return string.Empty; // Return an empty string or handle other errors
            }
        }
    }
}
