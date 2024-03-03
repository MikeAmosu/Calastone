
using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using ContentFilterApp.Core.ContentFilters;

namespace ContentFilterApp.FilterApp;

public class FilterApp : IFilterApp
{
    private readonly IContentFilter _contentFilter;

    public FilterApp(IContentFilter contentFilter)
    {
        _contentFilter = contentFilter;
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
        }        
    }
}
