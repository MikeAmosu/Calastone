using ContentFilterApp.Core.ContentFillters.Interface;
using System.Text;
using System.Text.RegularExpressions;

namespace ContentFilterApp.Core.ContentFillters.Filter.Words;

public class ExcludeWordFilter : IFilter
{
    public ExcludeWordFilter(string charsToExclude)
    {
        _charsToExclude = charsToExclude;
    }

    private string _charsToExclude;

    public string CreateRules()
    {
        if (string.IsNullOrEmpty(_charsToExclude))
        {
            throw new ArgumentNullException("_charsToExclude", $"No rules defined in {nameof(ExcludeWordFilter)}");
        }

        return $"\\b[^{_charsToExclude}\\W]+\\b";
    }

    public string Process(string text, string rules)
    {
        var rgx = new Regex(rules, RegexOptions.Multiline);
        var matches = rgx.Matches(text);

        var sb = new StringBuilder();
        if (matches.Count > 0)
        {
            foreach (Match item in matches)
            {
                if( item.Success )
                {
                    sb.Append($"{item.Value} ");
                }
            }
        }

        return sb.ToString().Trim();
    }
}
