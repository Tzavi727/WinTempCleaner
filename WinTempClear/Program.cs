using WinTempClear;

FileService fileService = new();

string tempPath = fileService.GetTempPath();

var tempFiles = fileService.GetTempFiles(tempPath);

var tempDir = fileService.GetTempDirectories(tempPath);

fileService.CleanTempFiles(tempFiles);
fileService.CleanTempDirectories(tempDir);

Console.WriteLine($"{fileService.deleteCount} Files Deleted!");
Console.WriteLine($"{fileService.failedDeleteCount} Files couldn't be deleted, Probably by being in use by an application or needing administrator access");