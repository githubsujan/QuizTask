using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;

namespace QuizApi.Helper
{
    public static class EncryptDecrypt
    {
        //ecrypts password to Base64 format 
        public static string EncryptPasswordToBase64(string password)
        {
            try
            {
                byte[] encrypt_byte = new byte[password.Length];
                encrypt_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encryptedPassword = Convert.ToBase64String(encrypt_byte);
                return encryptedPassword;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //decrypts password from Base64 format
        public static string DecryptFromBase64(string encryptedPassword)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] decrypt_byte = Convert.FromBase64String(encryptedPassword);
                int charCount = utf8Decode.GetCharCount(decrypt_byte, 0, decrypt_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(decrypt_byte, 0, decrypt_byte.Length, decoded_char, 0);
                string decryptedPassword = new String(decoded_char);
                return decryptedPassword;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
