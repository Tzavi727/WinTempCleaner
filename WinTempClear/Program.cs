using WinTempClear;

FileService fileService = new();
UIHelper uIHelper = new(fileService);

string tempPath = fileService.GetTempPath();

var tempFiles = fileService.GetTempFiles(tempPath);

var tempDir = fileService.GetTempDirectories(tempPath);

fileService.CleanTempFiles(tempFiles);
fileService.CleanTempDirectories(tempDir);

uIHelper.ShowFailedFiles();
uIHelper.ShowFailedDirectories();
uIHelper.ShowDeletedFilesCount();
uIHelper.ShowDeletedDirCount();