using ContentFilterApp.Core.ContentFillters.Interface;
using System.Text;
using System.Text.RegularExpressions;

namespace ContentFilterApp.Core.ContentFillters.Filter.Words;

public class LengthCheckWordFilter : IFilter
{
    public LengthCheckWordFilter(int? lessThanLengthRule, int? greaterThanLengthRule)
    {
        _lessThanLengthRule = lessThanLengthRule;
        _greaterThanLengthRule = greaterThanLengthRule;
    }


    private readonly int? _lessThanLengthRule;
    private readonly int? _greaterThanLengthRule;

    public string CreateRules()
    {        
        if (!_greaterThanLengthRule.HasValue && !_lessThanLengthRule.HasValue)
        {
            throw new ArgumentNullException($"No rules defined in {nameof(LengthCheckWordFilter)}");
        }

        if(_greaterThanLengthRule.HasValue && _greaterThanLengthRule == 0)
        {
            throw new ArgumentException("Parameter greaterThan must be > 0", "_greaterThanLengthRule");
        }

        if (_lessThanLengthRule.HasValue && _lessThanLengthRule == 0)
        {
            throw new ArgumentException("Parameter lessThan must be > 0", "_lessThanLengthRule");
        }
        
        if (_lessThanLengthRule.HasValue && _greaterThanLengthRule.HasValue
            && _lessThanLengthRule.Value > _greaterThanLengthRule.Value)
        {
            throw new ArgumentException("Parameter lessThan must be less than parameter greaterThan");
        }

        var greaterThanStr = _greaterThanLengthRule.HasValue ? _greaterThanLengthRule.Value.ToString() : "";
        var lessThanStr = _lessThanLengthRule.HasValue ? _lessThanLengthRule.Value.ToString() : "";

        if( greaterThanStr != "" &&  lessThanStr == "" )
        {
            lessThanStr = "1";
        }

        return $"\\b\\w{{{lessThanStr},{greaterThanStr}}}\\b";
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
