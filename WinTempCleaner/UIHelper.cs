using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner
{
    internal class UIHelper
    {
        private readonly FileService FileService;

        public UIHelper(FileService fileService)
        {
            this.FileService = fileService;
        }
        public void ShowDeletedFilesCount()
        {
            Console.WriteLine($"{FileService.DeletedFileCount} Files Deleted!");
        }
        public void ShowDeletedDirCount()
        {
            Console.WriteLine($"{FileService.DeletedDirCount} Files deleted ");
        }
        public void FinishedMessage()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
        public void ShowEndingSummary()
        {
            Console.WriteLine("======================= WIN TEMP CLEANER =======================");
            Console.WriteLine($"- Deleted: {FileService.DeletedFileCount} Files. -");
            Console.WriteLine($"- Deleted: {FileService.DeletedDirCount} Directories. -");
            Console.WriteLine($"- Skipped: {FileService.FailedFileDeleteCount} Files (In use or Permission Denied). -");
            Console.WriteLine($"- Skipped: {FileService.FailedDirDeleteCount} Directories (In use or Permission Denied). -");
        }
    }
}
