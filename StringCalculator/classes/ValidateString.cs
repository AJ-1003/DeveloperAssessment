using System.Configuration;

namespace StringCalculator
{
    public class ValidateString
    {
        public static bool StringValidation(string userInput)
        {
            bool validated;
            string numbers = "";

            string regexInputString = @"(\d?[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]*)+";
            string regexOutputString = @"[\\\,\;\:_\*\^\%\$\#\/\|\&\=\.\s\n]*";

            RegexStringValidator regexInputValidator = new RegexStringValidator(regexInputString);
            //RegexStringValidator regexOutputValidator = new RegexStringValidator(regexOutputString);

            Console.WriteLine(userInput);

            if (regexInputValidator.CanValidate(userInput.GetType()))
            {
                try
                {
                    // Attempt validation.
                    regexInputValidator.Validate(userInput);

                    numbers = userInput.Replace(regexOutputString, ",");

                    validated = true;

                    Console.WriteLine(numbers);

                    Console.WriteLine("The total is: " + AddNumbers.Add(numbers));
                }
                catch (ArgumentException e)
                {
                    // Validation failed.
                    Console.WriteLine("Error: {0}", e.Message.ToString());
                    validated = false;
                }
            }
            else
            {
                Console.WriteLine("Failed");
                validated = false;
            }

            return validated;
        }
    }
}
