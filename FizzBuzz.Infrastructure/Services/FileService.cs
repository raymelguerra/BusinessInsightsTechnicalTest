using FizzBuzz.Infrastructure.Exceptions;
using FizzBuzz.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FizzBuzz.Infrastructure.Services;

public class FileService(IConfiguration configuration) : IFileService
{
    private static readonly SemaphoreSlim FileLock = new(1, 1);
    private readonly string _filePath = configuration["FilePath"] ?? "fizzbuzz.log";

    public async Task SaveToFileAsync(string content)
    {
        try
        {
            await FileLock.WaitAsync();
            await File.AppendAllTextAsync(_filePath, content + Environment.NewLine);
        }
        catch (Exception ex)
        {
            throw new FileWriteException("Error writing file", ex);
        }
        finally
        {
            FileLock.Release();
        }
    }
}