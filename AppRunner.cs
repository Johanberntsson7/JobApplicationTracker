using System.Collections;
using Microsoft.VisualBasic;

namespace JobApplicationTracker;

public class AppRunner
{
    JobManager jobManager = new JobManager();

    public void Run()
    {
        bool run = true;
        while (run)
        
        {
            MenuHelper.ShowMenu();
            int.TryParse(Console.ReadLine(), out int option);
            Console.Clear();
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
                run = false;
                break;
                default:
                Console.WriteLine("Choose an option (1-8)");
                break;
                
                
            }
            
            
        }
        
        
    }
}
