namespace StringCalculatorLibrary
{
    public class Class1
    {

    }

    public static class Calculator
    {
        private static readonly List<string> _delimiters = new List<string> { ",", "\n" };
        private static readonly int _maxNumberAllowed = 1500;

        public static int Add(string input)
        {
            _delimiters.AddRange(ExtractCustomDelimiters(input));

            var numberPortion = HasCustomDelimiters(input)
                ? input.Split("\n", 2, StringSplitOptions.RemoveEmptyEntries)[1]
                : input;

            var numbers = numberPortion
                .Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            EnsureNoNegativesIn(numbers);

            var filteredNumbers = FilterNumbersLessThanOrEqualToMaxAllowed(numbers);

            return filteredNumbers.Sum();
        }

        private static int[] FilterNumbersLessThanOrEqualToMaxAllowed(int[] numbers)
        {
            return numbers
                .Where(n => n <= _maxNumberAllowed)
                .ToArray();
        }

        private static void EnsureNoNegativesIn(int[] numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0);

            if (negativeNumbers.Any())
            {
                throw new Exception($"Negative numbers not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }

        private static bool HasCustomDelimiters(string input)
        {
            return input.StartsWith("//");
        }

        private static List<string> ExtractCustomDelimiters(string input)
        {
            if (!HasCustomDelimiters(input))
            {
                return new List<string>();
            }


            var delimitersString = input.Split("\n", 2)[0];

            if(delimitersString[2] != '[')
            {
                return new List<string> { delimitersString[2].ToString() };
            }

            return new List<string>();
        }
    }
}