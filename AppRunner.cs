using System.Collections;
using Microsoft.VisualBasic;

namespace JobApplicationTracker;


// AppRunner – styr programmet: visar menyn och anropar rätt metod
public class AppRunner
{
    JobManager jobManager = new JobManager();

    // Run() – håller programmet igång tills användaren väljer att avsluta
    public void Run()
    {
        // run styr loopen: true = fortsätt, false = avsluta
        bool run = true;
        while (run)
        
        {
            // Visar menyn
            MenuHelper.ShowMenu();

            // Läser in valet. Om användaren skriver bokstäver blir option 0
            int.TryParse(Console.ReadLine(), out int option);

            // Rensar skärmen så den gamla menyn inte ligger kvar
            Console.Clear();

            // switch väljer vad som händer beroende på siffran
            switch(option)
            {
                case 1:
                jobManager.AddJob();
                break;
                case 2:
                jobManager.ShowAll();
                break;
                case 3:
                jobManager.ShowByStatus();
                break;
                case 4:
                jobManager.sortedbydate();
                break;
                case 5:
                jobManager.ShowStatistics();
                break;
                case 6: 
                jobManager.UpdateStatus();
                break;
                case 7:
                jobManager.RemoveJobApplication();
                break;
                case 8:
                // Gör loopen falsk, så programmet avslutas
                run = false;
                break;
                default:
                // Körs om siffran inte matchar något case ovan
                Console.WriteLine("Choose an option (1-8)");
                break;
                
                
            }
            
            
        }
        
        
    }
}
