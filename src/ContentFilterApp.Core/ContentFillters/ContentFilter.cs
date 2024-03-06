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

    public async Task<string> ProcessFile(IFilter[] filters, string? filePath = null)
    {
        var textContexts = await _fileReaderService.ReadFile(filePath).ConfigureAwait(false);
        return ApplyFilters(textContexts, filters);
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
            _logger.LogError(ex, "{className}.{methodName} Error occurred applying filters", nameof(ContentFilter), nameof(ApplyFilters));
            throw;
        }

        return filteredContent;
    }
}
