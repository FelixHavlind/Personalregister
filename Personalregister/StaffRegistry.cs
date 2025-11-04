using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PersonalRegister.Tests")]

namespace Personalregister;

// Intern data och metoder är "internal" istället för "private" för att de ska vara nåbara från "Personalregister.Tests"
public static class StaffRegistry
{
    internal record Staff(string Name, int Salary);
    
    internal static readonly List<Staff> StaffList = [];
    internal static bool Running = true;
    
    public static void Run()
    {
        Console.WriteLine("Welcome to staff register!");
        
        // Huvudloop
        while (Running)
        {
            Console.WriteLine("\nChoose an option: \n" +
                              "(1) Add staff to registry\n" +
                              "(2) List registry\n" +
                              "(0) Exit");

            // Läser in användarens val, default-värde är en ogiltig integer "-1".
            var option = int.Parse(Console.ReadLine() ?? "-1");

            /*
                Hantering av användarens val med en switch där relevant metod exekveras.
                Nya metoder kan även definieras här samt implementeras som en metod nedanför.
            */
            switch (option)
            {
                case 1: AddStaffToRegistry(); break;
                case 2: ListRegistry(); break;
                case 0: Exit(); break;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }
    
    // OPTIONS
    internal static void AddStaffToRegistry()
    {
        Console.WriteLine("\nAdding new staff...");
        
        Console.Write("Provide staff name: ");
        var name = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Provide staff salary: ");
        var salary = int.Parse(Console.ReadLine() ?? "0");
        
        StaffList.Add(new Staff(name, salary));
        Console.WriteLine($"Added staff with name {name} and salary {salary} to registry.");
    }
    internal static void ListRegistry()
    {
        Console.WriteLine("\nListing staff registry...");

        foreach (var everyStaff in StaffList)
        {
            Console.WriteLine(everyStaff.Name + ", " + everyStaff.Salary);
        }
    }
    internal static void Exit()
    {
        Console.WriteLine("\nQuitting...");
        Running = false;
    }
}