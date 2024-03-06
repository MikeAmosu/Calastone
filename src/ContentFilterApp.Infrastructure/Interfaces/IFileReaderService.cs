namespace ContentFilterApp.Infrastructure.Interfaces;

public interface IFileReaderService
{
    Task<string> ReadFile(string? newfilePath = null);
}