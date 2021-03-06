using System.Configuration;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AddNumbers
    {
        public static int maxAllowedNumbers = 3;
        public static string regexInputString = @"(\d?[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]*)+";

        public static RegexStringValidator stringValidator = new RegexStringValidator(regexInputString);

        // Integers
        int total = 0;
        int intNumber;
        int numberOfNegativeValues = 0;

        int[] negativeNumbers = new int[0];

        public bool ContainsNegativeNumbers()
        {
            return negativeNumbers.Length > 0;
        }

        public void CheckNumberValue(int number, string[] numbersString)
        {
            string negativeNumberPattern = @"\-*\d+";

            int negativeNumberValue;

            Match negativeMatch = Regex.Match(numbersString[number], negativeNumberPattern);
            // Negative code block
            if (Int32.Parse(negativeMatch.Value) < 0)
            {
                negativeNumberValue = Int32.Parse(negativeMatch.Value);
                numberOfNegativeValues++;
                Array.Resize(ref negativeNumbers, numberOfNegativeValues);
                negativeNumbers[numberOfNegativeValues - 1] = negativeNumberValue;
                //containsNegatives = true;
                // Test outputs
                //Console.WriteLine("Negative number value: " + negativeNumberValue);
                //Console.WriteLine("Negative numbers array length: " + negativeNumbers.Length);
                //Console.WriteLine("Negative number values: " + numberOfNegativeValues);
                //Console.WriteLine("Lenght of negative array: " + negativeNumbers.Length);
            }
            else
            {
                intNumber = Int32.Parse(numbersString[number]);
                if (intNumber > 1000)
                {
                    intNumber = 0;
                }
                else
                {
                    total += intNumber;
                }
            }
            //return containsNegatives;
        }

        public static void negativeNumberOutput(int val)
        {
            Console.WriteLine("=> {0:d}", val);
        }

        public int Add(string numbers)
        {

            // Stings
            string regexString = @"[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]+";
            string replacement = ",";

            // Regex
            Regex regexOutputString = new Regex(regexString);

            // Working Strings
            string inputNumbers = numbers.TrimStart().TrimEnd();
            string outputNumbers = regexOutputString.Replace(inputNumbers, replacement);

            // Arrays
            string[] numbersString = outputNumbers.Split(',');

            Action<int> action = new Action<int>(negativeNumberOutput);

            try
            {
                if (numbers != "" && numbersString.Length > 0)
                {
                    for (int number = 0; number < numbersString.Length; number++)
                        CheckNumberValue(number, numbersString);
                }
                else
                {
                    total = 0;
                }

                if (negativeNumbers.Length > 0)
                    throw new NegativeNumberException($"The following negatives are not allowed:");
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
                Array.ForEach(negativeNumbers, action);
                for (int i = 0; i < 40; i++)
                    Console.Write("=");

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return total;
        }
    }
}
