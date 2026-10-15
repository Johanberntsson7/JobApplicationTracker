using System.Runtime.InteropServices.Marshalling;

namespace JobApplicationTracker;


public static class MenuHelper
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the job application tracker");
        Console.WriteLine("1) Add an application");
        Console.WriteLine("2) Show all applications");
        Console.WriteLine("3) Show applications status");
        Console.WriteLine("4) Sort applications by date");
        Console.WriteLine("5) Show statistics");
        Console.WriteLine("6) Update an application");
        Console.WriteLine("7) Remove application");
        Console.WriteLine("8) Exit program");
        Console.ResetColor();
        Console.WriteLine("Choose an option:");
        
    }
}