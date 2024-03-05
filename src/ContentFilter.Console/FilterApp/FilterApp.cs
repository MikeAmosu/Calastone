
using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using ContentFilterApp.Core.ContentFilters;
using Microsoft.Extensions.Logging;

namespace ContentFilterApp.FilterApp;

public class FilterApp : IFilterApp
{
    private readonly IContentFilter _contentFilter;
    private readonly ILogger<FilterApp> _logger;

    public FilterApp(IContentFilter contentFilter)
    public FilterApp(IContentFilter contentFilter,
                     ILogger<FilterApp> logger)
    {
        _contentFilter = contentFilter;
        _logger = logger;
    }

    public void Handle()
    {
        try
        {
            IFilter[] filters = new IFilter[]
            {
                new LengthCheckWordFilter(3, null),
                new ExcludeWordFilter($"tT"),
                new MiddleCharVowelWordFilter($"AaEeIiOoUu")
            };
            var filePath = "../../../../ContentFilterApp.Infrastructure/Files/Data.txt";
            var filteredText = _contentFilter.ProcessFile(filters, filePath);

            Console.WriteLine(filteredText);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _logger.LogError(ex, "{className}.{methodName} error thrown {message}", nameof(FilterApp), nameof(Handle), ex.Message);
        }        
    }
}
