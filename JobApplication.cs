namespace JobApplicationTracker
{
    public enum ApplicationStatus
    {
        Applied = 1,
        Interview = 2,
        Offer = 3,
        Rejected = 4,
        Salary = 5
    }
    public class JobApplication
    {       
        // Attributer
        public string? CompanyName { get; set; } 
        public string? PositionTitle { get; set; } 
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime ResponseDate { get; set; }
        public int SalaryExpectation {get; set; } 

            // Metoder 
         public int GetDaysSinceApplied()
        {
             return (DateTime.Today - ApplicationDate).Days;
         }

         public string GetSummary()
         {
             return $"{CompanyName} - {PositionTitle} (Applied: {ApplicationDate:yyyy-MM-dd})";
         }
    }
}  