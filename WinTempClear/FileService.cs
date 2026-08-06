using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempClear
{
    internal class FileService
    {
        public int deleteCount { get; private set; } = 0;
        public int failedDeleteCount { get; private set; } = 0;

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

        public void CleanTempDirectories(string[] directories)
        {
            foreach (var dir in directories)
            {
                try
                {
                    Directory.Delete(dir, true);
                    deleteCount++;
                }
                catch (IOException)
                {
                    Console.WriteLine($"The directory {Path.GetFileName(dir)} could not be deleted");
                    failedDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"The directory {Path.GetFileName(dir)} could not be deleted");
                    failedDeleteCount++;
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
                    deleteCount++;
                }

                catch (IOException)
                {
                    Console.WriteLine($"The file {Path.GetFileName(file)} could not be deleted");
                    failedDeleteCount++;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"The file {Path.GetFileName(file)} could not be deleted");
                    failedDeleteCount++;
                }
            }
        }
    }
}
