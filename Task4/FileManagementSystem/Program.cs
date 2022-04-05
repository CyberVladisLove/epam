using System;
using System.IO;
using FileManagementSystem.MonitoringMode;
using FileManagementSystem.RollbackMode;
using CustomLib;

namespace FileManagementSystem
{
    /// <summary>
    /// При первом запуске создаётся файл хранения хеша(journal) и папка версий основной папки(versions) на одном уровне с папкой для отслеживания(folder).
    /// В journal пишется хеш сумма папки, а её версии сохраняются в versions.
    /// При запуске мониторинга прога ждёт, пока пользователь закончит работу и сообщит об этом, нажав любую клавишу в консоли.
    /// После нажатия прога сравнивает текущий хеш папки с хешом из journal. Если они отличаются то коммитит новую версию и пишет её хеш в journal.
    /// При откате прога так же сохранит новую версию и запишет её хеш.
    /// Пути папок хранятся в Paths.cs
    /// </summary>
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write(
                    "===Выберите действие===\n" +
                    "1. Наблюдение\n" +
                    "2. Откатить\n" +
                    "3. Выйти\n" +
                    "Ввод:"
                    );

                int val = CustomInput.ReadOnlyNumber(1, 3);
                Console.Clear();
                switch (val)
                {
                    case 1:
                        Monitoring.Invoke();
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
}
