﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tested
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    class AES_Encrypt
    {
        static readonly string aes_key = "wQpxkQNAxqULHUsAy/cuTnzyrF1LYGLkbOyozXv6Kag=";
        static readonly string aes_iv = "6u7xI5cHMyssVBeLDAZBlA==";

        public static void AesEDM(string original)
        {

            //string original = "Hello World!";

            try
            {
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes(original, Convert.FromBase64String(aes_key), Convert.FromBase64String(aes_iv));

                // Decrypt the bytes to a string.
                string roundtrip = DecryptStringFromBytes(encrypted, Convert.FromBase64String(aes_key), Convert.FromBase64String(aes_iv));

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("encrypted:   {0}", Convert.ToBase64String(encrypted));
                Console.WriteLine("roundtrip: {0}", roundtrip);

                Console.WriteLine("===========================");

                // Encrypt the string to an array of bytes.
                string str_encrypted = EncryptAES(original);

                // Decrypt the bytes to a string.
                //str_encrypted = "cOwH7hLNER8bumvPVSRIEryjBQc6aAKi7rihs2eugUE=";
                string str_roundtrip = DecryptAES(str_encrypted);

                Console.WriteLine("Original: {0}", str_encrypted);
                Console.WriteLine("Round Trip: {0}", str_roundtrip);

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public static string EncryptAES(string plainText)
        {
            byte[] encrypted;

            using (AesManaged aes = new AesManaged())
            {
                aes.Key = Convert.FromBase64String(aes_key);
                aes.IV = Convert.FromBase64String(aes_iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Convert.FromBase64String(aes_key);
                aes.IV = Convert.FromBase64String(aes_iv);

                ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptAES(string encryptedText)
        {
            string decrypted = null;
            //string var = null;
            //byte[] DecryptedData;
            byte[] cipher = Convert.FromBase64String(encryptedText);

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Convert.FromBase64String(aes_key);
                aes.IV = Convert.FromBase64String(aes_iv);
                //aes.IV = cipher[15..];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                //aes.BlockSize = 128;
                //aes.KeySize = 256;

                ICryptoTransform dec = aes.CreateDecryptor();
                //DecryptedData = dec.TransformFinalBlock(cipher, 16, cipher.Length - 16);
                //var = Encoding.UTF8.GetString(DecryptedData);
                //byte [] var = dec.TransformFinalBlock(cipher, 16, cipher.Length -16);
                //System.Text.Encoding.UTF8.GetString(var);
                using (MemoryStream ms = new MemoryStream(cipher))
                {

                    using CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read);
                    using StreamReader sr = new StreamReader(cs);
                    decrypted = sr.ReadToEnd();
                }
                aes.Dispose();
            }
            var result_encrypt = decrypted[15..].Trim();
            Console.WriteLine("Originals:{0}", result_encrypt);
            //Console.WriteLine("Original_de:{0}", decrypted);
            return decrypted;
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}

