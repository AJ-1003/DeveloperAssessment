using StringCalculator;
using System.Text;

//int inputCount = 0;
StringBuilder numbers = new();
string userInput;
string emptyUserInput = "0";

static void separationLine()
{
    for (int i = 0; i < 40; i++)
    {
        Console.Write("=");
    }
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
    for (int inputCount = 0; inputCount < AddNumbers.maxAllowedNumbers; inputCount++)
    {
        userInput = Console.ReadLine();

        if (userInput != "")
        {
            appendStringBuilder(userInput, inputCount, numbers);
        }
        else
        {
            appendStringBuilder(emptyUserInput, inputCount, numbers);
        }
    }
    separationLine();
    Console.WriteLine("The total is: " + AddNumbers.Add(numbers.ToString()));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.Read();