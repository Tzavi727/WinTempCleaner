string tempPath = Path.GetTempPath();

var tempFiles = Directory.GetFiles(tempPath);

var tempDirectories = Directory.GetDirectories(tempPath);

int filesCount = 0;
int failCount = 0;

foreach (var file in tempFiles)
{
    try
    {
        File.Delete(file);
        filesCount++;
    }
    catch (IOException )
    {
        Console.WriteLine($"The file {Path.GetFileName(file)} could not be deleted");
        failCount++;
    }
}

foreach (var dir in tempDirectories)
{
    try
    {
        Directory.Delete(dir,true);
        filesCount++;
    }
    catch (IOException)
    {
        Console.WriteLine($"The directory {Path.GetFileName(dir)} could not be deleted");
        failCount++;
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"The directory {Path.GetFileName(dir)} could not be deleted");
        failCount++;
    }
}

Console.WriteLine($"{filesCount} Files Deleted!");
Console.WriteLine($"{failCount} Files couldn't be deleted, Probably by being in use by an application or needing administrator access");