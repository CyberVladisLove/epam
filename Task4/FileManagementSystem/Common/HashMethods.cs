using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Common
{
    public class HashMethods
    {
        public static string GetFileHash(string path)//хеш значение файла
        {
            FileStream fs = File.OpenRead(path);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(fs);
            fs.Close();

            return BitConverter.ToString(checkSum)
                               .Replace("-", string.Empty);
        }
        public static string GetStringHash(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(str);

            return BitConverter.ToString(md5.ComputeHash(bytes))
                               .Replace("-", String.Empty);
        }
        public static string GetFolderHash(string folder)
        {
            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(folder, "*.*", SearchOption.AllDirectories);
            var sb = new StringBuilder();
            foreach (string file in files)
            {
                sb.Append(GetFileHash(file))
                  .Append(GetStringHash(file));
            }
            foreach (string dir in directories)
            {
                sb.Append(GetStringHash(dir));
            }
            return GetStringHash(sb.ToString());
        }
    }
}
