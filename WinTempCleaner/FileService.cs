using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner
{
    internal class FileService
    {
        public bool isRunning { get; private set; } = false;
        public int DeletedFileCount { get; private set; } = 0;
        public int FailedFileDeleteCount { get; private set; } = 0;
        public int DeletedDirCount { get; private set; } = 0;
        public int FailedDirDeleteCount { get; private set; } = 0;
        public List<string> tempFileErrorName { get; private set; } = new List<string>();
        public List<string> tempDirErrorName { get; private set; }  = new List<string>();

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
            isRunning = true;

            return Task.Run(async () =>
            {
                try
                {
                    CleanTempFiles(files);
                    CleanTempDirectories(directories);

                    //Delay just so the user can actually see the "animation".
                    await Task.Delay(5000);
                }
                finally { isRunning = false; }
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
                    tempDirErrorName.Add(Path.GetDirectoryName(dir) ?? "Unnamed Directory");
                    FailedDirDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    tempDirErrorName.Add(Path.GetDirectoryName(dir) ?? "Unnamed Directory");
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
                    tempFileErrorName.Add(Path.GetFileName(file) ?? "Unnamed File");
                    FailedFileDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    tempFileErrorName.Add(Path.GetFileName(file) ?? "Unnamed File");
                    FailedFileDeleteCount++;
                }
            }
        }
    }
}
