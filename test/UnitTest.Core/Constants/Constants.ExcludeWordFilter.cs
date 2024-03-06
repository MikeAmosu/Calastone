namespace UnitTest.Core.TestUtils;

public static partial class Constants
{
    public static class ExcludeWordFilter
    {
        public static readonly ExcludeFilterTestConditions Expected1 = new ExcludeFilterTestConditions("a", "xax xxxx", "xxxx");
        public static readonly ExcludeFilterTestConditions Expected2 = new ExcludeFilterTestConditions("aA", "xax xAx xxxx", "xxxx");

        public static readonly ExcludeFilterTestConditions Expected3 = new ExcludeFilterTestConditions("t", "xtx xxxx", "xxxx");
        public static readonly ExcludeFilterTestConditions Expected4 = new ExcludeFilterTestConditions("tT", "xtx xTx xxxx", "xxxx");

        public static readonly ExcludeFilterTestConditions Expected5 = new ExcludeFilterTestConditions("a1b2", "xax x1x xbx x2x xxxx", "xxxx");
        public static readonly ExcludeFilterTestConditions Expected6 = new ExcludeFilterTestConditions("aAtT12", "xtTx xaAx x12x xxxx", "xxxx");

        public static readonly ExcludeFilterTestConditions Expected7 = new ExcludeFilterTestConditions("xX", "xtTx xaAx x12x xxxx", "");
        public static readonly ExcludeFilterTestConditions Expected8 = new ExcludeFilterTestConditions("klKl", "x1x x2x x3x x4x", "x1x x2x x3x x4x");

        public static readonly string NoRulesDefinedErrorMessage =
            $"No rules defined in {nameof(ContentFilterApp.Core.ContentFillters.Filter.Words.ExcludeWordFilter)} (Parameter '_charsToExclude')";
    }
}
