using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using UnitTest.Core.TestUtils;

namespace UnitTest.Core.Filters
{
    public class MiddleCharVowelWordFilterTests
    {
        private IFilter CreateWordFilter(string rule)
        {
            return new MiddleCharVowelWordFilter(rule);
        }

        [Theory]
        [MemberData(nameof(ValidMiddleCharExcludeWordRules))]
        public void MiddleCharVowelWordFilter_ValidRule_ReturnsExpectedResult(ExcludeFilterTestConditions testConditions)
        {
            //Arrange
            var service = CreateWordFilter(testConditions.Rules);

            //Act
            var rules = service.CreateRules();
            var result = service.Process(testConditions.Content, rules);

            //Assert
            Assert.Equal(testConditions.Expected, result);
        }

        [Fact]
        public void MiddleCharVowelWordFilter_EnterEmptyRule_ReturnsArgumentNullException()
        {
            //Arrange
            var service = CreateWordFilter("");

            //Act
            var ex = Assert.Throws<ArgumentNullException>("_charsToFind", () => service.Process(Constants.MiddleCharVowelWordFilter.Expected1.Content, string.Empty));

            //Assert
            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(Constants.MiddleCharVowelWordFilter.NoCharacterDefinedAsRuleErrorMessage, ex.Message);
        }

        public static IEnumerable<object[]> ValidMiddleCharExcludeWordRules()
        {
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected1 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected2 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected3 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected4 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected5 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected6 };
            yield return new[] { Constants.MiddleCharVowelWordFilter.Expected7 };
        }
    }
}