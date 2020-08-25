using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    public class EnJD
    {

        public static string DecodeJD()
        {
            string result = "";
            var c = "AARko4uBHlbNtVu/jsIKRODOVMqsuqQXxk+ycDBLWEQdrOHFAb+1M0lxaw6pmzj8ywiFv3dhvE26eswBopAxaKdNWOAsDd/QrsmvuH3RP4JUityrY4bpINejuuWN66SepL+juRN85mk2MTodA5XqYgLq";

            var str64 = DecodeBase64(Encoding.UTF8, c);

            //byte[] decodedByteArray = Convert.FromBase64String(c);

            var hex = GetHex(str64);

            

            var keyId = GetHex(DecodeBase64(Encoding.UTF8, "ZKOLgR5WzbVbv47CCkTgzg =="));
            Console.WriteLine(hex);

            Console.WriteLine(keyId);
            //————————————————
            //版权声明：本文为CSDN博主「Nemo_XP」的原创文章，遵循CC 4.0 BY - SA版权协议，转载请附上原文出处链接及本声明。
            //原文链接：https://blog.csdn.net/spw55381155/java/article/details/80755901


            var key_string = "4i4qYVUje7HM7vZDvyv / A5FH8K0Fpl04SFQUQkYfwTY =";
            var keystr = DecodeBase64(Encoding.Default, key_string);
            var key = GetHex(keystr);
            hex = hex.Replace("0004", "");
            hex = hex.Replace(keyId, "");


            //string pic = Convert.ToBase64String(keystr);

            //base64string到byte[]再到图片的转换：
            byte[] bytes = Convert.FromBase64String(key_string);

            //byte[] bytes = Convert.FromBase64String(keystr);
            Console.WriteLine(hex);
            var her = Decrypt(Encoding.UTF8.GetBytes(hex)
                , bytes);
            //var b16=string.Format("{0:x}", Convert.ToInt32(decodedByteArray, 2));
            return her.ToString();
        }


        public static string GetHex(string str)
        {
            var encode = Encoding.UTF8;
            var bytes = encode.GetBytes(str);
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                //{0:X2} 大写
                ret.AppendFormat("{0:x2}", b);
            }
            var hex = ret.ToString();
            return hex;

        }

        public static byte[] Decrypt(byte[] ct, byte[] key)
        {

            // Check arguments.
            if (ct == null || ct.Length == 0)
                throw new ArgumentNullException("ciphertext is null or empty.");
            else if (key == null || key.Length == 0)
                throw new ArgumentNullException("key is null or empty.");
            // Declare the string used to hold
            // the decrypted text.
            byte[] decipher = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[ct.Length - iv.Length];

                Array.Copy(ct, iv, iv.Length);
                Array.Copy(ct, iv.Length, cipherText, 0, cipherText.Length);

                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = 16 * 8;
                //aesAlg.BlockSize = 512;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipherText, 0, cipherText.Length);
                        csDecrypt.Close();
                    }
                    decipher = msDecrypt.ToArray();
                }
            }

            return decipher;
        }



        /// <summary>
        /// Base64 解码
        /// </summary>
        /// <param name="encode">解码方式</param>
        /// <param name="source">要解码的字符串</param>
        /// <returns>返回解码后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string source)
        {
            string result = "";
            byte[] bytes = Convert.FromBase64String(source);
            try
            {
                result = encode.GetString(bytes);
            }
            catch
            {
                result = source;
            }
            return result;
        }
        //————————————————
        //版权声明：本文为CSDN博主「MeGoodtoo」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
        //原文链接：https://blog.csdn.net/MeGoodtoo/java/article/details/80318086
    }
}
