
using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using ContentFilterApp.Core.ContentFilters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContentFilterApp.FilterApp;

public class FilterApp : IFilterApp
{
    private readonly IContentFilter _contentFilter;
    private readonly ILogger<FilterApp> _logger;

    private readonly string[] _fileList;

    public FilterApp(IContentFilter contentFilter,
                     ILogger<FilterApp> logger,
                     IOptions<AppOptions> options)
    {
        _contentFilter = contentFilter;
        _logger = logger;
        _fileList = options.Value.Files;
    }

    public async Task Handle()
    {
        try
        {
            IFilter[] filters = new IFilter[]
            {
                new LengthCheckWordFilter(3, null),
                new ExcludeWordFilter($"tT"),
                new MiddleCharVowelWordFilter($"AaEeIiOoUu")
            };

            await Task.WhenAll(
                _fileList.Select(async filePath => { 
                    var text = await _contentFilter.ProcessFile(filters, filePath).ConfigureAwait(false);
                    Console.WriteLine("\n" + text); 
                }));

            Console.ReadLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _logger.LogError(ex, "{className}.{methodName} error thrown {message}", nameof(FilterApp), nameof(Handle), ex.Message);
        }        
    }
}
