using AsyncTaskDataOtusSolution.Services;
using System.Diagnostics;
using System.Text;

internal class Program
{
    static async Task Main(string[] args)
    {
        UserReadFile userReadFile = new UserReadFile();
        Dictionary<string, int> fileSpaceCounts = new Dictionary<string, int>();
        var directoryPath = Console.ReadLine();

        var files = Directory.GetFiles(directoryPath);
        Stopwatch stopwatch = Stopwatch.StartNew();
        var tasks = files.Select(async file =>
        {
            int spaceCount = await userReadFile.ReadFileAsync(file);
            return (file, spaceCount);
        });
        var results = await Task.WhenAll(tasks);
        stopwatch.Stop();
        foreach (var result in results)
        {
            fileSpaceCounts[result.file] = result.spaceCount;
        }

        foreach(var kvp in fileSpaceCounts)
        {
            Console.WriteLine($"{kvp.Key}, пробелов: {kvp.Value}");
        }
        Console.WriteLine($"время выполнение: {stopwatch.ElapsedMilliseconds}мс");
    }
}