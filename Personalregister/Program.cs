namespace Personalregister;

internal static class Program
{
    private record Staff(string Name, int Salary);
    
    private static readonly List<Staff> StaffList = [];
    private static bool _running = true;
    
    private static void Main()
    {
        Console.WriteLine("Welcome to staff register!");
        
        while (_running)
        {
            Console.WriteLine("\nChoose an option: \n" +
                              "(1) Add staff to registry\n" +
                              "(2) List registry\n" +
                              "(3) Exit");

            var option = int.Parse(Console.ReadLine() ?? string.Empty);

            if (option.GetType() != typeof(int))
            {
                Console.WriteLine("\nInvalid input, please try again!");
                continue;
            }

            switch (option)
            {
                case 1: AddStaffToRegistry(); break;
                case 2: ListRegistry(); break;
                case 3: Exit(); break;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    private static void AddStaffToRegistry()
    {
        Console.WriteLine("\nAdding new staff...");
        
        Console.Write("Provide staff name: ");
        var name = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Provide staff salary: ");
        var salary = int.Parse(Console.ReadLine() ?? string.Empty);
        
        StaffList.Add(new Staff(name, salary));
    }
    private static void ListRegistry()
    {
        Console.WriteLine("\nListing staff registry...");

        foreach (var everyStaff in StaffList)
        {
            Console.WriteLine(everyStaff.Name + ", " + everyStaff.Salary);
        }

        Console.ReadKey();
    }
    private static void Exit()
    {
        Console.WriteLine("\nQuitting...");
        _running = false;
    }
}