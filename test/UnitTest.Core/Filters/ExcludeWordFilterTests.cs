using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using UnitTest.Core.TestUtils;

namespace UnitTest.Core.Filters
{
    public class ExcludeWordFilterTests
    {
        private IFilter CreateWordFilter(string rule)
        {
            return new ExcludeWordFilter(rule);
        }

        [Theory]
        [MemberData(nameof(ValidExcludeWordRules))]
        public void ExcludeWordFilter_ValidRule_ReturnsExpectedResult(ExcludeFilterTestConditions testConditions)
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
        public void ExcludeWordFilter_EnterEmptyRule_ReturnsArgumentNullException()
        {
            //Arrange
            var service = CreateWordFilter("");

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => service.CreateRules());

            //Assert
            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(ex.Message, Constants.ExcludeWordFilter.NoRulesDefinedErrorMessage);
        }

        public static IEnumerable<object[]> ValidExcludeWordRules()
        {
            yield return new[] { Constants.ExcludeWordFilter.Expected1 };
            yield return new[] { Constants.ExcludeWordFilter.Expected2 };
            yield return new[] { Constants.ExcludeWordFilter.Expected3 };
            yield return new[] { Constants.ExcludeWordFilter.Expected4 };
            yield return new[] { Constants.ExcludeWordFilter.Expected5 };
            yield return new[] { Constants.ExcludeWordFilter.Expected6 };
            yield return new[] { Constants.ExcludeWordFilter.Expected7 };
            yield return new[] { Constants.ExcludeWordFilter.Expected8 };
        }
    }
}