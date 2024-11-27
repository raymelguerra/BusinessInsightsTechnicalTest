namespace FizzBuzz.Infrastructure.Exceptions;

public class InvalidInputException(string message) : Exception(message);