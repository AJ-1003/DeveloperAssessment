using LinkedLists.classes;

LinkedList linkedList = new LinkedList();
Console.WriteLine("Is the list empty?: " + linkedList.Empty);
Console.WriteLine("Size of list: " + linkedList.Count);

linkedList.Add("1");
linkedList.Add("2");
linkedList.Add(1, "3");
Console.WriteLine();

linkedList.PrintList();
Console.WriteLine();

linkedList.Remove(1);
linkedList.PrintList();
Console.WriteLine();

linkedList.Clear();
linkedList.PrintList();