using FizzBuzz.Infrastructure.Exceptions;
using FizzBuzz.Infrastructure.Interfaces;

namespace FizzBuzz.Infrastructure.Services;

public class FizzBuzzService(IFileService fileService) : IFizzBuzzService
{
    public async Task<List<string>> GenerateAndSaveAsync(int start, int limit)
    {
        if (start > limit)
            throw new InvalidInputException("The starting number cannot be greater than the limit.");
        
        var series = FizzBuzzGenerator.Generate(start, limit);
        
        var timestampedSeries = $"{DateTime.UtcNow:MM/dd/yyyy-h:mm:ss tt zz}: {string.Join(", ", series)}";
        
        await fileService.SaveToFileAsync(timestampedSeries);

        return series;
    }
}
