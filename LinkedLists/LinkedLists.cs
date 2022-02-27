using LinkedLists.classes;

static void SeparationLine()
{
    for (int i = 0; i < Console.WindowWidth; i++)
    {
        Console.Write("=");
    }
    Console.WriteLine();
}

static void InitialList()
{
    LinkedList linkedList = new LinkedList();

    Console.WriteLine("Enter 5 items you want to add to a list (Press 'Enter' after each item):");
    object input;

    for (int i = 0; i < 5; i++)
    {
        input = Console.ReadLine();
        linkedList.AddToFront(input);
    }
    SeparationLine();
    ShowList(linkedList);
}

static void ShowList(LinkedList linkedList)
{
    Console.WriteLine("Would you like to view the your list? (Y/N)");
    string showList = Console.ReadLine().ToLower();

    switch (showList)
    {
        case "y":
            SeparationLine();
            Console.WriteLine("Your list below:");
            linkedList.PrintList();
            break;
        case "n":
            SeparationLine();
            ShowActions(linkedList);
            break;
        default:
            SeparationLine();
            Console.WriteLine("Please enter 'Y'(Yes) or 'N'(No).");
            showList = Console.ReadLine().ToLower();
            break;
    }
    SeparationLine();
    ShowActions(linkedList);
}

static void ShowActions(LinkedList linkedList)
{
    Console.WriteLine("What would you like to do next? (Only enter the action number)\n" +
        "1 - Add new item to front of list\n" +
        "2 - Add new item to end of list\n" +
        "3 - Add new item at specified index\n" +
        "4 - Remove specified item from list\n" +
        "5 - Exit application");
    string actionOption = Console.ReadLine();
    SeparationLine();
    CheckActionOption(actionOption, linkedList);
}

static void CheckActionOption(string actionOption, LinkedList linkedList)
{
    string[] actionOptions = { "1", "2", "3", "4", "5" };

    if (!actionOptions.Contains(actionOption))
    {
        Console.WriteLine("Please select one of the options listed (Only enter the action number)");
        actionOption = Console.ReadLine();
        SeparationLine();
        PerformAction(actionOption, linkedList);
    }
    else
    {
        PerformAction(actionOption, linkedList);
    }
}

static void PerformAction(string actionOption, LinkedList linkedList)
{
    switch (actionOption)
    {
        case "1":
            Console.WriteLine("Please enter the item you would like to add to the front:");
            object newFrontItem = Console.ReadLine();
            linkedList.AddToFront(newFrontItem);
            SeparationLine();
            Console.WriteLine("Updated list below:");
            linkedList.PrintList();
            SeparationLine();
            ShowActions(linkedList);
            break;
        case "2":
            Console.WriteLine("Please enter the item you would like to add to the end:");
            object newEndItem = Console.ReadLine();
            linkedList.AddToEnd(newEndItem);
            SeparationLine();
            Console.WriteLine("Updated list below:");
            linkedList.PrintList();
            SeparationLine();
            ShowActions(linkedList);
            break;
        case "3":
            Console.WriteLine("Please enter the item you would like to add and its position respectively:");
            object newItem = Console.ReadLine();
            int itemIndex = Int32.Parse(Console.ReadLine());
            linkedList.Add(itemIndex, newItem);
            SeparationLine();
            Console.WriteLine("Updated list below:");
            linkedList.PrintList();
            SeparationLine();
            ShowActions(linkedList);
            break;
        case "4":
            Console.WriteLine("Please enter the item you would like to remove's position:");
            int removeIndex = Int32.Parse(Console.ReadLine());
            linkedList.Remove(removeIndex);
            SeparationLine();
            Console.WriteLine("Updated list below:");
            linkedList.PrintList();
            SeparationLine();
            ShowActions(linkedList);
            break;
        case "5":
            Environment.Exit(0);
            break;
        default:
            break;
    }
}

try
{
    InitialList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}