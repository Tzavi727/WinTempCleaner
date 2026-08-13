using WinTempCleaner.Helpers;
using WinTempCleaner.Services;

FileService fileService = new();
var loadingService = new LoadingService(fileService);
UIHelper uIHelper = new(fileService);

string tempPath = fileService.GetTempPath();
var tempFiles = fileService.GetTempFiles(tempPath);
var tempDir = fileService.GetTempDirectories(tempPath);

Task task1 = fileService.CleanAll(tempFiles, tempDir);
Task task2 = loadingService.LoadingAnimation();

await Task.WhenAll(task1, task2);

Console.Clear();
uIHelper.ShowEndingSummary();
uIHelper.FinishedMessage();