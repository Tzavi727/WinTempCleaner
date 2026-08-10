using WinTempCleaner.Interfaces;

namespace WinTempCleaner.Helpers
{
    internal class UIHelper
    {
        private readonly IFileService fileService;

        public UIHelper(IFileService fileService)
        {
            this.fileService = fileService;
        }
        public void ShowDeletedFilesCount()
        {
            Console.WriteLine($"{fileService.DeletedFileCount} Files Deleted!");
        }
        public void ShowDeletedDirCount()
        {
            Console.WriteLine($"{fileService.DeletedDirCount} Files deleted ");
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
            Console.WriteLine($"- Deleted: {fileService.DeletedFileCount} Files. -");
            Console.WriteLine($"- Deleted: {fileService.DeletedDirCount} Directories. -");
            Console.WriteLine($"- Skipped: {fileService.FailedFileDeleteCount} Files (In use or Permission Denied). -");
            Console.WriteLine($"- Skipped: {fileService.FailedDirDeleteCount} Directories (In use or Permission Denied). -");
        }
    }
}
