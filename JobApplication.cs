namespace JobApplicationTracker
{
    public enum ApplicationStatus
    {
        // enum = en fast lista med namngivna värden för status
        // Siffrorna (1-4) matchar det användaren skriver i menyn
        Applied = 1,
        Interview = 2,
        Offer = 3,
        Rejected = 4,
        
    }
        // JobApplication – ritningen för en enda jobbansökan
        // string? och DateTime? betyder att värdet får vara tomt (null)
        public class JobApplication
    {       
        // Attributer
        public string? CompanyName { get; set; } 
        public string? PositionTitle { get; set; } 
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }

        // Tomt tills företaget har svarat
        public DateTime? ResponseDate { get; set; }
        public int SalaryExpectation { get; set; }

        // Metoder 
        // GetDaysSinceApplied() – räknar hur många dagar som gått sedan ansökan skickades
            public int GetDaysSinceApplied()
        {
            // Dagens datum minus ansökningsdatum, och bara antalet dagar returneras
            return (DateTime.Today - ApplicationDate).Days;
        }

            // GetSummary() – gör om ansökan till en lättläst text
        public string GetSummary()
        {
            // Om svarsdatum finns visas det, annars "N/A" (inte tillgängligt)
            string response = ResponseDate.HasValue ? ResponseDate.Value.ToString("yyyy-MM-dd") : "N/A";
            // Sätter ihop all information till en rad
            return $"{CompanyName} - {PositionTitle} (Applied: {ApplicationDate:yyyy-MM-dd} Status: {Status} ResponseTime: {response} SalaryExpectation: {SalaryExpectation})";
        }
    }
}  