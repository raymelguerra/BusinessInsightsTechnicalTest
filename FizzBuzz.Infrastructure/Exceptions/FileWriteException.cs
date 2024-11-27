namespace FizzBuzz.Infrastructure.Exceptions;

public class FileWriteException(string message, Exception innerException) : Exception(message, innerException);