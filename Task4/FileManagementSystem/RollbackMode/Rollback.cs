using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementSystem.MonitoringMode;
using FileManagementSystem.Common;
using CustomLib;

namespace FileManagementSystem.RollbackMode
{
    public class Rollback
    {
        public static void Invoke()
        {
            Console.WriteLine("Текущее время: " + DateTime.Now);
            Console.WriteLine("Выберите сохранение для отката:");
            
            string[] allVersions = PrintAllVersions();
            
            Console.Write("Ввод:");
            int n = CustomInput.ReadOnlyNumber(0, allVersions.Length-1);
            
            Directory.Delete(Paths.folder, true);
            FileMethods.DirCopy(allVersions[n], Paths.folder);

            string currentFolderHashSum = HashMethods.GetFolderHash(Paths.folder);
            FileMethods.WriteRecordToJournal(currentFolderHashSum);
            FileMethods.SaveCurrentVersion();
            Console.WriteLine($"Версия на момент {allVersions[n].Replace(Paths.versions, "")} восстановлена");
        }

        public static string[] PrintAllVersions()
        {
            string[] allVersions = Directory.GetDirectories(Paths.versions, "*", SearchOption.TopDirectoryOnly);
            if(allVersions.Length == 0)
            {
                Console.WriteLine("Не найдено ни одной версии папки");
            }
            for (int i = 0; i < allVersions.Length; i++)
            {   
                Console.WriteLine($"{i})\t{allVersions[i].Replace(Paths.versions, "")}");  
            }
            return allVersions;
        }
    }
}
