using ContentFilterApp.Core.ContentFillters.Interface;
using System.Text;
using System.Text.RegularExpressions;

namespace ContentFilterApp.Core.ContentFillters.Filter.Words;

public class MiddleCharVowelWordFilter : IFilter
{
    public MiddleCharVowelWordFilter(string charsToFind)
    {
        _charsToFind = !string.IsNullOrEmpty(charsToFind) ?
            charsToFind :
            $"aAeEiIoOuU";
    }

    private string _charsToFind;

    public string CreateRules()
    {
        StringBuilder rules = new StringBuilder("");

        if( string.IsNullOrEmpty(_charsToFind))
        {
            throw CreateNoCharactersDefinedException();
        }

        rules.Append($"[{_charsToFind}]");        
        return rules.ToString();
    }

    private ArgumentNullException CreateNoCharactersDefinedException()
    {
        return new ArgumentNullException($"No characters defined as rules in {nameof(MiddleCharVowelWordFilter)}");
    }

    public string Process(string text, string rules)
    {
        if (string.IsNullOrEmpty(rules))
        {
            throw CreateNoCharactersDefinedException();
        }

        var sb = new StringBuilder();

        var wordArray = new Regex("\\w*").Matches(text)
            .Where(x => !string.IsNullOrEmpty(x.Value))
            .Select(x => x.Value);

        var testRule = new Regex(rules);
        foreach(var word in wordArray)
        {
            var hasOneMiddleChar = word.Length % 2;
            var middleIdx = hasOneMiddleChar == 0 ?
                (word.Length - 1) / 2 :
                (int)(word.Length / 2);
            var centreChars = hasOneMiddleChar == 0 ?
                word.Substring(middleIdx, 2) :
                word.Substring(middleIdx, 1);

            if( !testRule.IsMatch(centreChars) )
            {
                sb.Append($"{word} ");
            }

        }
        
        return sb.ToString().Trim();
    }
}
