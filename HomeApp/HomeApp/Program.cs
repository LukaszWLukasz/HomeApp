using HomeApp;
using System.Drawing;
using System.Runtime.CompilerServices;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Hi! Welcome in HOME APP ");
Console.WriteLine("In App you can add positive or negative points for members of family");
Console.ResetColor();

bool toClose = false;

while (!toClose)
{
    Console.WriteLine();
    Console.WriteLine("1. Add point for members to the memory and display statistics");
    Console.WriteLine("2. Add point for members to the file.txt and display statistics");
    Console.WriteLine("3. Close");

    Console.WriteLine("(Press key 1  |  2 |  3 )");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddPointToMemory();
            break;

        case "2":
            AddPointToFile();
            break;

        case "3":
            toClose = true;
            Console.WriteLine("Bye Bye!");
            break;

        default:
            Console.WriteLine("Invalid operation");
            break;
    }
}
static void MemberPointAdded(object sender, EventArgs args)
{
    Console.WriteLine("(Point Added)");
}
static void AddPointToMemory()
{
    Console.WriteLine("Please, enter the member name of family: ");
    string name = Console.ReadLine();
    Console.WriteLine("Please, enter the member surname of family: ");
    string surname = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var member = new FamilyInMemory(name, surname);
        member.PointAdded += MemberPointAdded;
        AddPoints(member);
        member.GetStatisticsApp();
        member.ShowStatisticsApp();

    }
    else
    {
        Console.WriteLine("You have to enter name and surname member of family");
    }
}

static void AddPointToFile()
{
    Console.WriteLine("Please, enter the member name of family: ");
    string name = Console.ReadLine();
    Console.WriteLine("Please, enter the member surname of family: ");
    string surname = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var member = new FamilyInFile(name, surname);
        member.PointAdded += MemberPointAdded;
        AddPoints(member);
        member.GetStatisticsApp();
        member.ShowStatisticsApp();
    }
    else
    {
        Console.WriteLine("You have to enter name and surname member of family");
    }
}
static void AddPoints(IFamily member)
{
    while (true)
    {
        Console.WriteLine($"Enter point for {member.Name} {member.Surname}");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            member.AddPoint(input);

        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
        finally
        {
            Console.WriteLine("To stop add point you have to enter Q or q");
        }
    }
}







