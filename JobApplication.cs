namespace JobApplicationTracker
{
    public enum ApplicationStatus
    {
        Applied, Interview, Offer, Rejected
    }
    public class JobApplication
    {       
        // Attributer
        public string CompanyName { get; set; } = string.Empty; 
        public string PositionTitle { get; set; } = string.Empty;
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