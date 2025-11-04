namespace Personalregister;

internal static class Program
{
    private static readonly List<Staff> StaffList = [];
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to staff register!");
        var running = true;
        
        while (running)
        {
            Console.WriteLine("\nChoose an option: \n" +
                              "(1) Add staff to registry\n" +
                              "(2) List registry\n" +
                              "(3) Exit");
            
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("\nAdding new staff...");
                    Console.Write("Provide staff name: ");
                    var name = Console.ReadLine() ?? string.Empty;
                    Console.Write("Provide staff salary: ");
                    var salary = int.Parse(Console.ReadLine() ?? string.Empty);
                    StaffList.Add(new Staff(name, salary));
                    break;
                }
            
                case "2":
                {
                    Console.WriteLine("\nListing staff registry...");

                    foreach (var everyStaff in StaffList)
                    {
                        Console.WriteLine(everyStaff.Name + ", " + everyStaff.Salary);
                    }

                    Console.ReadKey();
                    break;
                }
            
                case "3":
                {
                    Console.WriteLine("\nQuitting...");
                    running = false;
                    break;
                }

                default:
                {
                    Console.WriteLine("\nInvalid command!");
                    break;
                }
            }   
        }
    }
}