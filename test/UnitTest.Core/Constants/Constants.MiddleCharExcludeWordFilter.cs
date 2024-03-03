namespace UnitTest.Core.TestUtils;

public static partial class Constants
{
    public static class MiddleCharVowelWordFilter
    {
        private static readonly string TestRule = $"AaEeIiOoUu";

        public static readonly ExcludeFilterTestConditions Expected1 =
            new ExcludeFilterTestConditions(TestRule,
                                            "jar xxxx",
                                            "xxxx");

        public static readonly ExcludeFilterTestConditions Expected2 =
            new ExcludeFilterTestConditions(TestRule,
                                            "been xxxx",
                                            "xxxx");

        public static readonly ExcludeFilterTestConditions Expected3 =
            new ExcludeFilterTestConditions(TestRule,
                                            "jar jer jor jir jur jAr jEr jIr jOr jUr xxxx",
                                            "xxxx");

        public static readonly ExcludeFilterTestConditions Expected4 =
            new ExcludeFilterTestConditions(TestRule,
                                            "baan been biin boon buun xxxx",
                                            "xxxx");

        public static readonly ExcludeFilterTestConditions Expected5 =
            new ExcludeFilterTestConditions(TestRule,
                                            "Tast Test Tist Tost Tust xxxx",
                                            "xxxx");

        public static readonly ExcludeFilterTestConditions Expected6 =
            new ExcludeFilterTestConditions(TestRule,
                                            "She took down a jar from one of the shelves as she passed",
                                            "She one the shelves she passed");

        public static readonly ExcludeFilterTestConditions Expected7 =
            new ExcludeFilterTestConditions(TestRule,
                                            "This has to be a test where I get Failed or Ive been Passed",
                                            "Ive Passed");

        public static readonly string NoCharacterDefinedAsRuleErrorMessage =
            $"Value cannot be null. (Parameter 'No characters defined as rules in {nameof(ContentFilterApp.Core.ContentFillters.Filter.Words.MiddleCharVowelWordFilter)}')";
    }
}
