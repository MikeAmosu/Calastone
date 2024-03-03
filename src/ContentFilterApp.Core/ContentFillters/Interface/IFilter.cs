namespace ContentFilterApp.Core.ContentFillters.Interface;

public interface IFilter
{
    string CreateRules();
    string Process(string text, string rules);
}
