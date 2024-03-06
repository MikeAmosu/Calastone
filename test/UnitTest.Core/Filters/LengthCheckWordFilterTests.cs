using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using System.Text.RegularExpressions;
using UnitTest.Core.TestUtils;

namespace UnitTest.Core.Filters
{
    public class LengthCheckWordFilterTests
    {
        private IFilter CreateWordFilter(int? lessThan, int? greaterThan)
        {
            return new LengthCheckWordFilter(lessThan, greaterThan);
        }

        [Theory]
        [MemberData(nameof(ValidLengthWordRules))]
        public void LengthCheckWordFilter_ValidRule_ReturnsExpectedResult(LengthFilterTestConditions testConditions)
        {
            //Arrange
            var service = CreateWordFilter(testConditions.LessThan, testConditions.GreaterThan);

            //Act
            var rules = service.CreateRules();
            var result = service.Process(testConditions.Content, rules);

            //Assert
            Assert.Equal(testConditions.Expected, result);
        }

        [Fact]
        public void LengthCheckWordFilter_EnterEmptyRule_ReturnsArgumentNullException()
        {
            //Arrange
            var service = CreateWordFilter(null, null);

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => service.CreateRules());

            //Assert
            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(Constants.LengthCheckFilter.NoRulesDefinedErrorMessage, ex.Message);
        }

        [Fact]
        public void LengthCheckWordFilter_EnterZeroInGreaterThanArgument_ReturnsArgumentException()
        {
            //Arrange
            var service = CreateWordFilter(null, 0);

            //Act
            var ex = Assert.Throws<ArgumentException>("_greaterThanLengthRule", () => service.CreateRules());

            //Assert
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(Constants.LengthCheckFilter.ArgumentErrorForGreaterThanRulesErrorMessage, ex.Message);
        }

        [Fact]
        public void LengthCheckWordFilter_EnterZeroInLessThanArgument_ReturnsArgumentException()
        {
            //Arrange
            var service = CreateWordFilter(0, null);

            //Act
            var ex = Assert.Throws<ArgumentException>("_lessThanLengthRule", () => service.CreateRules());

            //Assert
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(Constants.LengthCheckFilter.ArgumentErrorForLessThanRulesErrorMessage, ex.Message);
        }

        [Fact]
        public void LengthCheckWordFilter_EnterInvalidParameters_ReturnsArgumentException()
        {
            //Arrange
            var service = CreateWordFilter(11, 1);

            //Act
            var ex = Assert.Throws<ArgumentException>(() => service.CreateRules());

            //Assert
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(Constants.LengthCheckFilter.ArgumentErrorInvalidParametersErrorMessage, ex.Message);
        }

        public static IEnumerable<object[]> ValidLengthWordRules()
        {
            yield return new[] { Constants.LengthCheckFilter.Expected1 };
            yield return new[] { Constants.LengthCheckFilter.Expected2 };
            yield return new[] { Constants.LengthCheckFilter.Expected3 };
            yield return new[] { Constants.LengthCheckFilter.Expected4 };
            yield return new[] { Constants.LengthCheckFilter.Expected5 };
            yield return new[] { Constants.LengthCheckFilter.Expected6 };
            yield return new[] { Constants.LengthCheckFilter.Expected7 };
            yield return new[] { Constants.LengthCheckFilter.Expected8 };
            yield return new[] { Constants.LengthCheckFilter.Expected9 };
        }
    }
}