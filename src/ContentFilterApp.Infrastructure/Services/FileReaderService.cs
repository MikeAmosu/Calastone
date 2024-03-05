using ContentFilterApp.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace ContentFilterApp.Infrastructure.Services;

public class FileReaderService : IFileReaderService
{
    private readonly ILogger<FileReaderService> _logger;
    private readonly string _filePath;

    public FileReaderService(ILogger<FileReaderService> logger)
    {
        _logger = logger;
        _filePath = string.Empty;
    }

    public async Task<string> ReadFile(string? newfilePath = null)
    {
        var newFilePathName = string.IsNullOrEmpty(newfilePath)
            ? _filePath 
            : newfilePath;

        if (!File.Exists(newFilePathName))
        {
            var errorStr = $"Unable to find File path {newFilePathName}";
            var ex = new FileNotFoundException(errorStr);
            _logger.LogError(ex, $"{{className}}.{{methodName}} {errorStr}", nameof(FileReaderService), nameof(ReadFile));
            throw ex;
        }

        string content = string.Empty;
        try 
        {
            using (var sr = new StreamReader(File.OpenRead(newFilePathName)))
            {
                content = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, $"{{className}}.{{methodName}} Error reading file!", nameof(FileReaderService), nameof(ReadFile));
            throw;
        }
        

        if (string.IsNullOrEmpty(content))
        {
            var errorStr = $"The file is empty. File Path: {newFilePathName}.";
            var ex = new Exception(errorStr);
            _logger.LogError(ex, $"{{className}}.{{methodName}} {errorStr}", nameof(FileReaderService), nameof(ReadFile));
            throw ex;
        }

        return content;
    }
}
