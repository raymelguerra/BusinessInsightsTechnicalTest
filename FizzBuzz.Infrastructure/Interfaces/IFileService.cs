namespace FizzBuzz.Infrastructure.Interfaces;

public interface IFileService
{
    Task SaveToFileAsync(string content);
}