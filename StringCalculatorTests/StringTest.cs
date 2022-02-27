using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void ContainsNegativeValues_StringContainsNegativeValues_NegativeArrayContainsValue()
        {
            // Arrange
            string[] numbers = { "-3, 3, 6" };
            AddNumbers addNumbers = new AddNumbers();


            // Act
            for (int number = 0; number < numbers.Length; number++)
                addNumbers.CheckNumberValue(number, numbers);

            // Assert
            Assert.IsTrue(addNumbers.ContainsNegativeNumbers());
        }

        [TestMethod]
        public void Add_GetTotal_ReturnedTotalMatch()
        {
            // Arrange
            string numbers = "3,3,6";
            AddNumbers addNumbers = new AddNumbers();
            int testTotal = 12;

            // Act
            var result = addNumbers.Add(numbers);

            // Assert
            Assert.AreEqual(testTotal, result);
        }
    }
}