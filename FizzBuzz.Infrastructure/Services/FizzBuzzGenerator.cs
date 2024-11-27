namespace FizzBuzz.Infrastructure.Services;

public static class FizzBuzzGenerator
{
    public static List<string> Generate(int start, int limit)
    {
        var result = new List<string>();

        for (int i = start; i <= limit; i++)
        {
            if (i % 15 == 0)
                result.Add("fizzbuzz");
            else if (i % 3 == 0)
                result.Add("fizz");
            else if (i % 5 == 0)
                result.Add("buzz");
            else
                result.Add(i.ToString());
        }

        return result;
    }
}