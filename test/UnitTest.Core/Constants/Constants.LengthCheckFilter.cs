using System.Reflection.Metadata;

namespace UnitTest.Core.TestUtils;

public static partial class Constants
{
    public static class LengthCheckFilter
    {
        private static readonly string testString = $"o to thr four fiveo sixooo sevenoo eightooo nineooooo tenooooooo";
        public static readonly LengthFilterTestConditions Expected1 = new LengthFilterTestConditions(9, null, testString, $"nineooooo tenooooooo");
        public static readonly LengthFilterTestConditions Expected2 = new LengthFilterTestConditions(1, null, testString, testString);
        public static readonly LengthFilterTestConditions Expected3 = new LengthFilterTestConditions(10, null, testString, "tenooooooo");

        public static readonly LengthFilterTestConditions Expected4 = new LengthFilterTestConditions(null, 2, testString, "o to");
        public static readonly LengthFilterTestConditions Expected5 = new LengthFilterTestConditions(null, 1, testString, "o");
        public static readonly LengthFilterTestConditions Expected6 = new LengthFilterTestConditions(null, 11, testString, testString);

        public static readonly LengthFilterTestConditions Expected7 = new LengthFilterTestConditions(2, 2, testString, "to");
        public static readonly LengthFilterTestConditions Expected8 = new LengthFilterTestConditions(3, 7, testString, "thr four fiveo sixooo sevenoo");
        public static readonly LengthFilterTestConditions Expected9 = new LengthFilterTestConditions(1, 12, testString, testString);

        public static readonly string NoRulesDefinedErrorMessage =
            $"Value cannot be null. (Parameter 'No rules defined in {nameof(ContentFilterApp.Core.ContentFillters.Filter.Words.LengthCheckWordFilter)}')";

        public static readonly string ArgumentErrorForGreaterThanRulesErrorMessage =
            $"Parameter greaterThan must be > 0 (Parameter '_greaterThanLengthRule')";

        public static readonly string ArgumentErrorForLessThanRulesErrorMessage =
            $"Parameter lessThan must be > 0 (Parameter '_lessThanLengthRule')";

        public static readonly string ArgumentErrorInvalidParametersErrorMessage =
            $"Parameter lessThan must be less than parameter greaterThan";
    }
}
