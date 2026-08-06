using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempClear
{
    internal class UIHelper
    {
        private readonly FileService fileService;

        public UIHelper(FileService fileService)
        {
            this.fileService = fileService;
        }

        public void ShowFailedFiles()
        {
            if (fileService.failedFileDeleteCount != 0)
            {
                foreach (string file in fileService.tempFileErrorName)
                {
                    Console.WriteLine($"The file {file} could not be deleted probably due to being in use by an application or needing administrator access");
                }
            }
        }
        public void ShowFailedDirectories()
        {
            if (fileService.failedDirDeleteCount != 0)
            {
                foreach (string file in fileService.tempDirErrorName)
                {
                    Console.WriteLine($"The file {file} could not be deleted probably due to being in use by an application or needing administrator access");
                }
            }
        }
        public void ShowDeletedFilesCount()
        {
            Console.WriteLine($"{fileService.deletedFileCount} Files Deleted!");
        }
        public void ShowDeletedDirCount()
        {
            Console.WriteLine($"{fileService.deletedDirCount} Files deleted ");
        }
    }
}
