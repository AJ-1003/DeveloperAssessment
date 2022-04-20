using StringCalculator;
using System.Text;

//int inputCount = 0;
StringBuilder numbers = new();
string? userInput;
string emptyUserInput = "0";

static void separationLine()
{
    Console.Write("========================================");
    Console.WriteLine();
}

static void appendStringBuilder(string input, int inputCount, StringBuilder numbers)
{
    if (inputCount < AddNumbers.maxAllowedNumbers - 1)
    {
        numbers.Append(input).Append(",");
    }
    else
    {
        numbers.Append(input);
    }
}

separationLine();
Console.WriteLine($"Enter {AddNumbers.maxAllowedNumbers} numbers you want to add up");

try
{
    AddNumbers addNumbers = new AddNumbers();

    for (int inputCount = 0; inputCount < AddNumbers.maxAllowedNumbers; inputCount++)
    {
        userInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(userInput))
        {
            appendStringBuilder(userInput, inputCount, numbers);
        }
        else
        {
            appendStringBuilder(emptyUserInput, inputCount, numbers);
        }
    }
    Console.WriteLine(numbers);
    separationLine();
    Console.WriteLine("The total is: " + addNumbers.Add(numbers.ToString()));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.Read();