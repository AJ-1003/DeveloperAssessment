using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void Add_ContainsNegativeValues_ThrowException()
        {
            // Arrange
            /* initialize objects */
            var negativeValues = new AddNumbers();
            string negativeTestString = "-6, 3, -8";

            // Act
            /* act on created object */
            var result = AddNumbers.Add(negativeTestString);
            result.contains

            // Assert
            Assert.IsTrue(result);
        }
    }
}