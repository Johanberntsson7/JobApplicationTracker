using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

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
        Console.WriteLine("Company:");
        string companyname = Console.ReadLine()!;
        Console.WriteLine("Position:");
        string positiontitle = Console.ReadLine()!;
        Console.WriteLine("status: 1: Applied 2: Interview 3: Offer 4: Rejected");
        int statusNumber = int.Parse(Console.ReadLine()!);
        ApplicationStatus status = (ApplicationStatus)statusNumber;
        Console.WriteLine("Application date (yyyy-mm-dd)");
        DateTime dateTime = DateTime.Parse(Console.ReadLine()!);
        Console.WriteLine("Salary Expectation:");
        int salaryexpectation = int.Parse(Console.ReadLine()!);

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
        
        
    }
    
    // UpdateStatus() – ändrar status på en befintlig ansökan
    public void UpdateStatus()
    {
        if (Application.Count == 0)
            {
                Console.WriteLine("No applications found");
            }
    }

    // ShowAll() – visar alla ansökningar
    public void ShowAll()
        {
            if (Application.Count == 0)
            {
                Console.WriteLine("No avalible application");
                return;
            }
            
            var sortedby = Application.OrderByDescending(app => app.ApplicationDate);
            
            foreach(var application in sortedby)
            {
                Console.WriteLine(application.GetSummary());
                Console.WriteLine($"{application.GetDaysSinceApplied()} days since applied ");
                
            }
            
        }   

           
        
        
    // ShowByStatus() – filtrerar med LINQ efter status (VG del)
        public void ShowByStatus()
        {
            // Fråga användaren efter en status (1-4)
            Console.WriteLine("status: 1: Applied 2: Interview 3: Offer 4: Rejected");
            // Gör om siffran till en ApplicationStatus
                if (!int.TryParse(Console.ReadLine(), out int statusNumber))
            {
                Console.WriteLine("Choose an option (1-4)");
                return;
            }
            ApplicationStatus status = (ApplicationStatus)statusNumber;

            List<JobApplication> sortedlist = Application.Where(app => app.Status == status).ToList();
            
            if(sortedlist.Count == 0)
            {
                Console.WriteLine("No application found");
                return;
            }
            foreach (var application in sortedlist)
            {
                Console.WriteLine(application.GetSummary());
            }
            
        }   

        public void sortedbydate()
        {
            List<JobApplication> sortedbydate = Application.OrderBy(a => a.ApplicationDate).ToList();
            if(sortedbydate.Count == 0)
            {
                Console.WriteLine("No application in the list");
                return;
            }
            foreach (var application in sortedbydate)
            {
                Console.WriteLine(application.GetSummary());
            }
        }



            
            
        
    // ShowStatistics() – visar statistik med LINQ (Count, Average, OrderBy, Where) (VG del)
    public void ShowStatistics()
        {
             if (Application.Count == 0)
            {
                Console.WriteLine("No application to show");
                return;
            }
             else
            {
                Console.WriteLine("----Statictics----");
                Console.WriteLine($"Total: {Application.Count}");

                bool hasResponse = Application.Any(a => a.ResponseDate != default);
                if (hasResponse)
                {
                    double averageResponse = Application
                        .Where(a => a.ResponseDate != default)
                        .Average(a => (a.ResponseDate!.Value - a.ApplicationDate).TotalDays);
                    Console.WriteLine($"Average response time: {averageResponse:F1} days");
                }
                else
                {
                    Console.WriteLine("No response yet");
                }

                int applied = Application.Count(app => app.Status == ApplicationStatus.Applied);
                int interview = Application.Count(app => app.Status == ApplicationStatus.Interview);
                int offer = Application.Count(app => app.Status == ApplicationStatus.Offer);
                int rejected = Application.Count(app => app.Status == ApplicationStatus.Rejected);
                

                Console.WriteLine($"Applied: {applied}");
                Console.WriteLine($"Intervieved: {interview}");
                Console.WriteLine($"Offer: {offer}");
                Console.WriteLine($"Rejected: {rejected}");
            }
        }

        public void RemoveJobApplication()
        {
            // vill kunna ta bort jobapplication
            if (Application.Count == 0)
            {
                Console.WriteLine("No applications found");
                return;
            }

            Console.WriteLine("Enter company name to remove:");
            string companyName = Console.ReadLine()!;

            JobApplication? applicationToRemove = Application
                .FirstOrDefault(app => app.CompanyName!.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (applicationToRemove == null)
            {
                Console.WriteLine("No matching application found");
                return;
            }

            Application.Remove(applicationToRemove);
            Console.WriteLine("Job application removed");
        }
    }
}


