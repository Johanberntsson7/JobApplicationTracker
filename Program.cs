using System.Security.Cryptography.X509Certificates;

namespace JobApplicationTracker;

class Program
{
    static void Main(string[] args)
    {
         JobManager test = new JobManager();
         
         test.AddJob();
         test.ShowAll();
         test.ShowByStatus();
         test.ShowStatistics();
         test.UpdateStatus();
         
         
        
    }
}
