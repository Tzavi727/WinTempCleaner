using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTempCleaner
{
    internal class LoadingService
    {
        private const string text = "Deleting Temporary Files";

        private int periodCount = 1;

        private readonly IFileService fileService;

        public LoadingService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public async Task LoadingAnimation()
        {
            while (fileService.IsRunning)
            {
                if (periodCount < 4)
                {
                    Console.Clear();
                    string loadingText = text;
                    loadingText += new string('.', periodCount);
                    Console.WriteLine(loadingText);
                    periodCount++;
                    await Task.Delay(1000);
                }
                else
                {
                    periodCount = 1;
                }
            }
        }
    }
}
