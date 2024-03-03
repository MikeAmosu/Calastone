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

    public string ReadFile(string? newfilePath = null)
    {
        var newFilePathName = string.IsNullOrEmpty(newfilePath)
            ? _filePath 
            : newfilePath;

        if (!File.Exists(newFilePathName))
        {
            var errorStr = $"Unable to find File path {newFilePathName}";
            var ex = new FileNotFoundException(errorStr);
            _logger.LogError(ex, errorStr);
            throw ex;
        }

        string content = string.Empty;
        try 
        {
            using (var sr = new StreamReader(File.OpenRead(newFilePathName)))
            {
                content = sr.ReadToEnd();
            }
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, $"Error reading file!");
            throw;
        }
        

        if (string.IsNullOrEmpty(content))
        {
            var errorStr = $"The file is empty. File Path: {newFilePathName}.";
            var ex = new Exception(errorStr);
            _logger.LogError(ex, errorStr);
            throw ex;
        }

        return content;
    }
}
