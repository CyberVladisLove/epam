using System;
using System.IO;
using FileManagementSystem.MonitoringMode;
using FileManagementSystem.RollbackMode;
using CustomLib;

namespace FileManagementSystem
{
    class Program
    {
        static void Main()
        {
            Console.Write(
                    "===Выберите действие===\n" +
                    "1. Наблюдение\n" +
                    "2. Откатить\n" +
                    "3. Выйти\n" +  
                    "Ввод:"
                    );

            int val = CustomInput.ReadOnlyNumber(1, 3);
            
            switch (val)
            {
                case 1:
                    Monitoring.Run();
                    break;
                case 2:
                    Rollback.Invoke();
                    break;
                case 3:  
                    break;
                default:
                    break;
            }
            
        }
    }
}
