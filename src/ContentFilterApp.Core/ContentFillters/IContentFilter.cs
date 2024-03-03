using ContentFilterApp.Core.ContentFillters.Interface;

namespace ContentFilterApp.Core.ContentFilters
{
    public interface IContentFilter
    {
        string ProcessFile(IFilter[] filters, string? filePath = null);
    }
}