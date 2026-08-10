using WinTempCleaner.Interfaces;

namespace WinTempCleaner.Services
{
    internal class FileService : IFileService
    {
        public bool IsRunning { get; private set; } = false;
        public int DeletedFileCount { get; private set; } = 0;
        public int FailedFileDeleteCount { get; private set; } = 0;
        public int DeletedDirCount { get; private set; } = 0;
        public int FailedDirDeleteCount { get; private set; } = 0;
        public List<string> TempFileErrorName { get; private set; } = new List<string>();
        public List<string> TempDirErrorName { get; private set; }  = new List<string>();

        public string GetTempPath()
        {
            return Path.GetTempPath();
        }

        public string[] GetTempFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        public string[] GetTempDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public Task CleanAll(string[] files, string[] directories)
        {
            IsRunning = true;

            return Task.Run(async () =>
            {
                try
                {
                    CleanTempFiles(files);
                    CleanTempDirectories(directories);

                    //Delay just so the user can actually see the "animation".
                    await Task.Delay(5000);
                }
                finally { IsRunning = false; }
            });
        }

        public void CleanTempDirectories(string[] directories)
        {
            foreach (var dir in directories)
            {
                try
                {
                    Directory.Delete(dir, true);
                    DeletedDirCount++;
                }
                catch (IOException)
                {
                    TempDirErrorName.Add(Path.GetDirectoryName(dir) ?? "Unnamed Directory");
                    FailedDirDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    TempDirErrorName.Add(Path.GetDirectoryName(dir) ?? "Unnamed Directory");
                    FailedDirDeleteCount++;
                }
            }
        }

        public void CleanTempFiles(string[] files)
        {
            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                    DeletedFileCount++;
                }

                catch (IOException)
                {
                    TempFileErrorName.Add(Path.GetFileName(file) ?? "Unnamed File");
                    FailedFileDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    TempFileErrorName.Add(Path.GetFileName(file) ?? "Unnamed File");
                    FailedFileDeleteCount++;
                }
            }
        }
    }
}
