namespace FizzBuzz.Infrastructure.Interfaces;

public interface IFizzBuzzService
{
    Task<List<string>> GenerateAndSaveAsync(int start, int limit);
}