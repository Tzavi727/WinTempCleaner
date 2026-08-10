namespace WinTempCleaner.Interfaces
{
    internal interface IFileService
    {
        bool IsRunning { get; }
        int DeletedFileCount { get; }
        int FailedFileDeleteCount { get; }
        int DeletedDirCount { get; }
        int FailedDirDeleteCount { get; }
        List<string> TempFileErrorName { get; }
        List<string> TempDirErrorName { get; }

        string GetTempPath();
        string[] GetTempFiles(string path);
        string[] GetTempDirectories(string path);
        void CleanTempDirectories(string[] directories);
        void CleanTempFiles(string[] files);
        Task CleanAll(string[] files, string[] directories);
    }
}
