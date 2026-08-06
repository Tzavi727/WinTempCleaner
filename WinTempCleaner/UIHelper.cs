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

        public void ShowFailedFiles()
        {
            if (FileService.FailedFileDeleteCount != 0)
            {
                foreach (string file in FileService.tempFileErrorName)
                {
                    Console.WriteLine($"The file {file} could not be deleted probably due to being in use by an application or needing administrator access");
                }
            }
        }
        public void ShowFailedDirectories()
        {
            if (FileService.FailedDirDeleteCount != 0)
            {
                foreach (string file in FileService.tempDirErrorName)
                {
                    Console.WriteLine($"The file {file} could not be deleted probably due to being in use by an application or needing administrator access");
                }
            }
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
