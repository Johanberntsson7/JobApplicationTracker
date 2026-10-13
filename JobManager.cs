using System.Runtime.CompilerServices;

namespace JobApplicationTracker
{
    public class JobManager
{   
    // skapar listan från JobApplication klass in i JobManager
    public List<JobApplication> Application = new List<JobApplication>();

    // skapar metoden till ansökningen
    // AddJob() – lägger till en ny ansökan
    public void AddJob()
    {
        Console.WriteLine("Company");
        string companyname = Console.ReadLine();
        Console.WriteLine("Position");
        string positiontitle = Console.ReadLine();
        Console.WriteLine("status: 1: Applied 2:Interview 3:Offer 4:Rejected");
        int statusNumber = int.Parse(Console.ReadLine());
        ApplicationStatus status = (ApplicationStatus)statusNumber;
        Console.WriteLine("Application date (yyyy-mm-dd)");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Salary Expectation");
        int salaryexpectation = int.Parse(Console.ReadLine());

        JobApplication newapplication = new JobApplication
        
        {
            CompanyName = companyname,
            PositionTitle = positiontitle,
            Status = status,
            ApplicationDate = dateTime,
            SalaryExpectation = salaryexpectation,


            
        };
        Application.Add(newapplication);
        Console.WriteLine("Job added");
        
        Console.ReadKey();
    }
    
    // UpdateStatus() – ändrar status på en befintlig ansökan
    public void UpdateStatus()
        {
            
        }

    // ShowAll() – visar alla ansökningar
    public void ShowAll()
        {
            
        }
        
    // ShowByStatus() – filtrerar med LINQ efter status (VG del)
        public void ShowByStatus()
        {
            
        }
    // ShowStatistics() – visar statistik med LINQ (Count, Average, OrderBy, Where) (VG del)
    public void ShowStatistics()
        {
            
        }

}
}
