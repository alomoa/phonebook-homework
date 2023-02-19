Dictionary<string, string> phonebook = new Dictionary<string, string>();


while (true)
{
	Console.WriteLine("Please enter a command");

	string[] arguments = Console.ReadLine().Trim().Split(" ");
	switch (arguments[0])
	{
		case "STORE":
			StoreEntry(arguments);
			break;
		case "GET":
			GetEntry(arguments);
			break;
		case "UPDATE":
			UpdateEntry(arguments);
			break;
		case "DEL":
			DeleteEntry(arguments);
			break;
		default:
			break;
	}

	Console.WriteLine("\n");
}

void DeleteEntry(string[] arguments)
{
    if (arguments.Length != 2)
    {
        Console.WriteLine("Please enter the correct number of params");
        return;
    }

	if (long.TryParse(arguments[1], out var number))
	{
		DeleteEntryUsingNumber(number);
	}
	else
	{
		string name = arguments[1];

		if (!phonebook.ContainsKey(name))
		{
			Console.WriteLine("Name does not exist");
		}
		string num = phonebook[name];
		phonebook.Remove(name);
		Console.WriteLine(String.Format("OK {0}", num));
	}
}

void DeleteEntryUsingNumber(long number)
{
    var keys = phonebook.Keys;
    foreach (var key in keys)
    {
        if (long.Parse(phonebook[key]) == number)
        {
            Console.WriteLine("OK");
            phonebook.Remove(key);
            return;
        }
    }

    Console.WriteLine("Could not find number");
}

void UpdateEntry(string[] arguments)
{

    string name = arguments[1];
    string number = arguments[2];

    if (!phonebook.ContainsKey(name))
    {
        Console.WriteLine("Entry does not exist, use STORE instead");
        return;
    }

    if (!long.TryParse(arguments[2], out long _))
    {
        Console.WriteLine("Please enter a valid number");
        return;
    }
    
    if (arguments[2].Length != 11)
    {
        Console.WriteLine("Please enter an 11 digit number");
		return;
	}



    phonebook[name] = number;
    Console.WriteLine(String.Format("Successfully updated {0} with number {1} to the phonebook", name, number));
}

void GetEntry(string[] arguments)
{
    if(arguments.Length != 2)
	{
        Console.WriteLine("Please enter the correct number of params");
        return;
    }

	string name = arguments[1];

	if (!phonebook.ContainsKey(name))
	{
		Console.WriteLine("Name does not exist");
		return;
	}

	string num = phonebook[name];
	Console.WriteLine(String.Format("OK {0}", num));
}

void StoreEntry(string[] arguments)
{
	if(arguments.Length != 3)
	{
		Console.WriteLine("Please enter the correct number of params");
		return;
	}

	string name = arguments[1];
	string number = arguments[2];

	if (phonebook.ContainsKey(name))
	{
		Console.WriteLine("Entry already exists, use UPDATE instead");
		return;
	}
   
    if (!long.TryParse(arguments[2], out long _))
	{
        Console.WriteLine("Please enter a valid number");
		return;
    }
	
	if (arguments[2].Length != 11)
	{
		Console.WriteLine("Please enter an 11 digit number");
		return;
	}

	phonebook[name] = number;
	Console.WriteLine(String.Format("Successfully added {0} with number {1} to the phonebook", name, number));
}