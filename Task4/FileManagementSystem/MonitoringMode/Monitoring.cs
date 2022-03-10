using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FileManagementSystem.Common;

namespace FileManagementSystem.MonitoringMode
{
    public class Monitoring
    {
        


        public static void Invoke()
        {

            if (!File.Exists(Paths.journal))
                CreateGit();

            if (FileMethods.GetFileSize(Paths.journal) == 0)
                InitGit();

            Console.WriteLine("После окончания работы нажмите любую клавишу для сохранения");
            Console.ReadKey();

            string currentFolderHashSum = HashMethods.GetFolderHash(Paths.folder);

            string[] journalRecords = FileMethods.ReadFileString(Paths.journal).Split('\n');

            string lastFolderHashSum = journalRecords.LastOrDefault();
            //Console.WriteLine("currentFolderHashSum: " + currentFolderHashSum);
            //Console.WriteLine("lastFolderHashSum: " + lastFolderHashSum);
            if (lastFolderHashSum != currentFolderHashSum)
            {
                FileMethods.WriteRecordToJournal(currentFolderHashSum);
                FileMethods.SaveCurrentVersion();
                Console.WriteLine("Изменения сохранены");
            }
            else Console.WriteLine("Изменений не обнаружено");
        }
        private static void CreateGit() //создание нужных папок и файлов
        {
            File.Create(Paths.journal).Dispose();  
            Directory.CreateDirectory(Paths.versions);
            Console.WriteLine("Гит создан");
        }

        private static void InitGit() //создание первой версии папки (init commit)
        {
            string currentFolderHashSum = HashMethods.GetFolderHash(Paths.folder);
            FileMethods.WriteRecordToJournal(currentFolderHashSum);
            FileMethods.SaveCurrentVersion();
            Console.WriteLine("Гит заполнен начальными данными");
        }
        




    }
}
