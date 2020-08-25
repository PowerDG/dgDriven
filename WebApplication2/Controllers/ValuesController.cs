using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public static string DecodeJD(Encoding encode, string source)
        {
            string result = "";
            var c = "AARko4uBHlbNtVu/jsIKRODOVMqsuqQXxk+ycDBLWEQdrOHFAb+1M0lxaw6pmzj8ywiFv3dhvE26eswBopAxaKdNWOAsDd/QrsmvuH3RP4JUityrY4bpINejuuWN66SepL+juRN85mk2MTodA5XqYgLq";

            var str64 = DecodeBase64(Encoding.Default ,c);
            result = str64;
            return result;
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
                aesAlg.BlockSize = 128;
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
