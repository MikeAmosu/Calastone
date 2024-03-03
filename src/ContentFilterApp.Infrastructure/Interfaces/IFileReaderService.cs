namespace ContentFilterApp.Infrastructure.Interfaces;

public interface IFileReaderService
{
    string ReadFile(string? newfilePath = null);
}