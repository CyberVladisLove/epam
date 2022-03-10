using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem.Common
{
    public class FileMethods
    {
        public static void WriteFile(string record, string file) //записать строку в файл
        {   
            FileStream fs = File.OpenWrite(file);
            fs.Write(Encoding.Default.GetBytes(record), 0, record.Length);
            fs.Dispose();
        }
        public static void DirCopy(string path1, string path2) //копировать папку
        {          
            foreach (string dirPath in Directory.GetDirectories(path1, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(path1, path2));
       
            foreach (string newPath in Directory.GetFiles(path1, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(path1, path2), true);
        }
        
        public static long GetFileSize(string path) => new FileInfo(path).Length; //размер файла

        public static byte[] ReadFileByte(string path) //чтение файла, результат байты
        {
            FileStream fs = File.OpenRead(path);
            byte[] checkContent = new byte[GetFileSize(path)];
            int i = fs.Read(checkContent, 0, checkContent.Length);
            fs.Close();
            return checkContent;
        }

        public static string ReadFileString(string path) //чтение файла, результат строка
            => Encoding.Default.GetString(ReadFileByte(path));

        public static void WriteRecordToJournal(string record) => WriteFile(record, Paths.journal);

        public static void SaveCurrentVersion() //сохраняет текущую версию папки folder в папку versions с фиксацией даты и времени
        {
            string new_folder = Paths.versions + Convert.ToString(DateTime.Now).Replace(":", ".") + "/";
            DirCopy(Paths.folder, new_folder);
        }
    }
}
