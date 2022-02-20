using System.Configuration;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AddNumbers
    {
        public static int maxAllowedNumbers = 3;
        public static string regexInputString = @"(\d?[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]*)+";

        public static RegexStringValidator stringValidator = new RegexStringValidator(regexInputString);

        public static void numberNegativeOutput(int val)
        {
            Console.WriteLine("=> {0:d}", val);
        }

        public static int Add(string numbers)
        {
            // Stings
            string regexString = @"[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]+";
            string negativeNumberPattern = @"\-*\d+";
            string replacement = ",";

            // Regex
            Regex regexOutputString = new Regex(regexString);

            // Working Strings
            string inputNumbers = numbers.TrimStart().TrimEnd();
            string outputNumbers = regexOutputString.Replace(inputNumbers, replacement);

            // Integers
            int total = 0;
            int intNumber;
            int negativeNumberValue;
            int numberOfNegativeValues = 0;

            // Arrays
            string[] numbersString = outputNumbers.Split(',');
            int[] negativeNumbers = new int[0];

            Action<int> action = new Action<int>(numberNegativeOutput);

            // Test outputs
            //Console.WriteLine("Array length: " + numbersString.Length);
            //Console.WriteLine("All input numbers: " + outputNumbers);

            try
            {
                if (numbers != "" && numbersString.Length > 0)
                {
                    for (int number = 0; number < maxAllowedNumbers; number++)
                    {
                        Match negativeMatch = Regex.Match(numbersString[number], negativeNumberPattern);
                        // Negative code block
                        if (Int32.Parse(negativeMatch.Value) < 0)
                        {
                            negativeNumberValue = Int32.Parse(negativeMatch.Value);
                            numberOfNegativeValues++;
                            Array.Resize(ref negativeNumbers, numberOfNegativeValues);
                            negativeNumbers[numberOfNegativeValues - 1] = negativeNumberValue;

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
                    }

                    if (negativeNumbers.Length > 0)
                    {
                        throw new NegativeNumberException($"The following negatives are not allowed:");
                    }
                }
                else
                {
                    total = 0;
                }
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
                Array.ForEach(negativeNumbers, action);
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("=");
                }
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
