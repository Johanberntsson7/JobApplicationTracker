using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace JobApplicationTracker
{ 
    public class JobManager
    {   
    // skapar listan från JobApplication klass in i JobManager
    public List<JobApplication> Application = new List<JobApplication>();
    

    // skapar metoden till ansökningen
    // AddJob() – frågar användaren efter uppgifter och lägger till en ny ansökan i listan
    public void AddJob()
    {
        // Läs in text från användaren
        Console.WriteLine("Company:");
        string companyname = Console.ReadLine()!;
        Console.WriteLine("Position:");
        string positiontitle = Console.ReadLine()!;

        // Användaren skriver en siffra (1-4) som görs om till en status (enum)
        Console.WriteLine("status: 1: Applied 2: Interview 3: Offer 4: Rejected");
        int.TryParse(Console.ReadLine(), out int statusnumber);
        ApplicationStatus status = (ApplicationStatus)statusnumber;

        // Texten användaren skriver görs om till ett datum
        Console.WriteLine("Application date (yyyy-mm-dd)");
        DateTime.TryParse(Console.ReadLine(),out DateTime dateTime );

         // Texten görs om till ett heltal
        Console.WriteLine("Salary Expectation:");
        int.TryParse(Console.ReadLine(),out int salaryexpectation);
        

         // Skapar ett nytt JobApplication-objekt och fyller det med uppgifterna ovan
        JobApplication newapplication = new JobApplication
        
        {
            CompanyName = companyname,
            PositionTitle = positiontitle,
            Status = status,
            ApplicationDate = dateTime,
            SalaryExpectation = salaryexpectation
        };
         
         // Lägger till objektet i listan
          Application.Add(newapplication);
          Console.WriteLine("Job has been added!");
        
        
    }
    
       // UpdateStatus() – låter användaren välja en ansökan och ändra dess status
    public void UpdateStatus()
    {
        if (Application.Count == 0)
        {
             // Avbryter om det inte finns några ansökningar att ändra
            Console.WriteLine("No applications found");
            return;
        }
            
            // Visa alla ansökningar med nummer, färgade efter status
        for (int i = 0; i < Application.Count; i++)
        {
            PrintColored(Application[i]);
            Console.WriteLine($"{i + 1}. {Application[i].GetSummary()}" );
            Console.ResetColor();
            
        }
            // Användaren väljer vilken ansökan som ska ändras (TryParse ger false om det inte är en siffra)
            Console.WriteLine("Choose an application number:");

        if (!int.TryParse(Console.ReadLine(), out int applicationNumber) ||
            applicationNumber < 1 || applicationNumber > Application.Count)
        {
            Console.WriteLine("Choose a valid application number");
            return;
        }
            
            // Användaren väljer ny status (1-4)
            Console.WriteLine("New status: 1: Applied 2: Interview 3: Offer 4: Rejected");

        if (!int.TryParse(Console.ReadLine(), out int statusNumber) || statusNumber < 1 || statusNumber > 4)
        {
            Console.WriteLine("Choose an option (1-4)");
            return;
        }

        // Listan börjar på 0 men användaren ser 1, därför -1
        // Sparar den nya statusen och dagens datum som svarsdatum
        Application[applicationNumber - 1].Status = (ApplicationStatus)statusNumber; // tog hjälp av claude.
        Application[applicationNumber - 1].ResponseDate = DateTime.Today; // samma här 
        Console.WriteLine("Application status updated");
        
    }

        // ShowAll() – visar alla ansökningar, nyaste först
    public void ShowAll()
        {
            // Avbryt om det inte finns några ansökningar
            if (Application.Count == 0)
            {
                Console.WriteLine("No avalible application");
                return;
            }
            
            // Sorterar efter ansökningsdatum, nyaste först (LINQ)
            var sortedby = Application.OrderByDescending(app => app.ApplicationDate);
            
             // Går igenom varje ansökan i den sorterade listan
            foreach(var application in sortedby)
            {
                // Sätter färg efter status
                PrintColored(application);
                Console.WriteLine(application.GetSummary());
                Console.WriteLine($"{application.GetDaysSinceApplied()} days since applied ");
                // Återställer färgen så nästa rad inte ärver den
                Console.ResetColor();
                
            }
            
        }   

           
        
        
    // ShowByStatus() – visar bara ansökningar med den status användaren väljer (LINQ) (VG-DEL)
        public void ShowByStatus()
        {
            // Fråga användaren efter en status (1-4)
            Console.WriteLine("status: 1: Applied 2: Interview 3: Offer 4: Rejected");

             // Avbryt om användaren inte skrev en siffra
            if (!int.TryParse(Console.ReadLine(), out int statusNumber))
            {
                Console.WriteLine("Choose an option (1-4)");
                return;
            }
            // Gör om siffran till en status (enum)
            ApplicationStatus status = (ApplicationStatus)statusNumber;

             // Filtrerar fram bara de ansökningar som har vald status (LINQ)
            List<JobApplication> sortedlist = Application.Where(app => app.Status == status).ToList();
            
            // Avbryt om ingen ansökan matchar
            if(sortedlist.Count == 0)
            {
                Console.WriteLine("No application found");
                return;
            }
             // Skriver ut varje matchande ansökan i sin färg
            foreach (var application in sortedlist)
            {
                PrintColored(application);
                Console.WriteLine(application.GetSummary());
                Console.ResetColor();
            }
            
        }   

            // sortedbydate() – visar alla ansökningar, äldsta först
        public void sortedbydate()
        {
            // Sorterar efter ansökningsdatum, äldsta först (LINQ)
            List<JobApplication> sortedbydate = Application.OrderBy(a => a.ApplicationDate).ToList();

            // Avbryt om listan är tom
            if(sortedbydate.Count == 0)
            {
                Console.WriteLine("No application in the list");
                return;
            }
            // Skriver ut varje ansökan i sin färg
            foreach (var application in sortedbydate)
            {
                PrintColored(application);
                Console.WriteLine(application.GetSummary());
                Console.ResetColor();
            }
        }

    // ShowStatistics() – visar statistik över ansökningarna med LINQ (Count, Average, OrderBy, Where) (VG del)
    public void ShowStatistics()
        {
            // Avbryt om det inte finns några ansökningar
             if (Application.Count == 0)
            {
                Console.WriteLine("No application to show");
                return;
            }
             else
            {
                Console.WriteLine("----Statictics----");
                // Count på listan ger totalt antal ansökningar
                Console.WriteLine($"Total: {Application.Count}");
                
                // Any kollar om minst en ansökan har fått svar
                bool hasResponse = Application.Any(a => a.ResponseDate != default);
                if (hasResponse)
                {
                    // Where behåller bara ansökningar med svar,
                    // Average räknar ut snittet av dagarna mellan ansökan och svar
                    double averageResponse = Application
                        .Where(a => a.ResponseDate != default)
                        .Average(a => (a.ResponseDate!.Value - a.ApplicationDate).TotalDays);
                        // :F1 visar bara en decimal
                    Console.WriteLine($"Average response time: {averageResponse:F1} days");
                }
                else
                {
                    Console.WriteLine("No response yet");
                }
                
                // Count med villkor räknar hur många ansökningar som har varje status
                int applied = Application.Count(app => app.Status == ApplicationStatus.Applied);
                int interview = Application.Count(app => app.Status == ApplicationStatus.Interview);
                int offer = Application.Count(app => app.Status == ApplicationStatus.Offer);
                int rejected = Application.Count(app => app.Status == ApplicationStatus.Rejected);
                
                // Skriver ut antalet för varje status
                Console.WriteLine($"Applied: {applied}");
                Console.WriteLine($"Intervieved: {interview}");
                Console.WriteLine($"Offer: {offer}");
                Console.WriteLine($"Rejected: {rejected}");
            }
        }

        // RemoveJobApplication() – tar bort en ansökan baserat på företagsnamn

        public void RemoveJobApplication()
        {
            List<JobApplication> removejob = Application.OrderBy(a => a.ApplicationDate).ToList();

            // Avbryt om det inte finns några ansökningar
            if (Application.Count == 0)
            {
                Console.WriteLine("No applications found");
                return;
            }

            // Användaren skriver namnet på företaget som ska tas bort
            foreach (var application in removejob )
            Console.WriteLine(application.GetSummary());
            Console.WriteLine("Enter company name to remove:");
            string companyName = Console.ReadLine()!;


            // Letar upp första ansökan med det företagsnamnet (LINQ)
            // OrdinalIgnoreCase gör att stora och små bokstäver inte spelar roll
             // FirstOrDefault ger null om ingen hittas
            JobApplication? applicationToRemove = Application
                .FirstOrDefault(app => app.CompanyName!.Equals(companyName, StringComparison.OrdinalIgnoreCase));
            
            // Avbryt om ingen ansökan matchade
            if (applicationToRemove == null)
            {
                Console.WriteLine("No matching application found");
                return;
            }

            // Tar bort ansökan ur listan
            Application.Remove(applicationToRemove);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Job application removed");
            Console.ResetColor();
            
        }


        // PrintColored() – sätter textfärgen i konsolen beroende på ansökans status
        private void PrintColored(JobApplication application)
        {       

            // Grå för Applied
            if(application.Status == ApplicationStatus.Applied)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            // Gul för Interview
            else if (application.Status == ApplicationStatus.Interview)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            // Grön för Offer
            else if (application.Status == ApplicationStatus.Offer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            // Röd för Rejected
            else if (application.Status == ApplicationStatus.Rejected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
                
                
        }
    }
}