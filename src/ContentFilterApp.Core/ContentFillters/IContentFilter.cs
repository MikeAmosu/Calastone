using ContentFilterApp.Core.ContentFillters.Interface;

namespace ContentFilterApp.Core.ContentFilters
{
    public interface IContentFilter
    {
        Task<string> ProcessFile(IFilter[] filters, string? filePath = null);
    }
}