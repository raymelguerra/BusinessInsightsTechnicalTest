namespace FizzBuzz.Infrastructure.Dtos;

public record FizzBuzzRequest
{
    public int Start { get; set; }
    public int Limit { get; set; }
}