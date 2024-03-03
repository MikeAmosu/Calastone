using ContentFilterApp.Core.ContentFillters.Interface;
using ContentFilterApp.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace ContentFilterApp.Core.ContentFilters;

public class ContentFilter : IContentFilter
{
    private readonly ILogger<ContentFilter> _logger;
    private readonly IFileReaderService _fileReaderService;

    public ContentFilter(ILogger<ContentFilter> logger, IFileReaderService fileReaderService)
    {
        _logger = logger;
        _fileReaderService = fileReaderService;
    }

    public string ProcessFile(IFilter[] filters, string? filePath = null)
    {
        var textContexts = ReadFile(filePath);
        return ApplyFilters(textContexts, filters);
    }

    private string ReadFile(string? filePath = null)
    {
        return _fileReaderService.ReadFile(filePath);
    }

    private string ApplyFilters(string content, IFilter[] filters)
    {
        string filteredContent = content;

        try
        {
            foreach (var filter in filters)
            {
                var rules = filter.CreateRules();
                filteredContent = filter.Process(filteredContent, rules);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred applying filters");
            throw;
        }

        return filteredContent;
    }
}
